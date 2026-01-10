// Tauri API
const { invoke } = window.__TAURI__.tauri;

// App State
let config = null;
let currentDatabase = null;
let databases = [];

// DOM Elements
const databaseSelector = document.getElementById('database-selector');
const gamesList = document.getElementById('games-list');
const artwork = document.getElementById('artwork');
const noArtwork = document.getElementById('no-artwork');
const manualBtn = document.getElementById('manual-btn');
const statusMessage = document.getElementById('status-message');
const closeAfterLaunch = document.getElementById('close-after-launch');

// Initialize
document.addEventListener('DOMContentLoaded', async () => {
    await loadConfig();
    await loadDatabases();
    setupTabs();
    setupStartupDbChange();
});

// Configuration
async function loadConfig() {
    try {
        config = await invoke('get_config');
        updateUIFromConfig();
    } catch (e) {
        setStatus(`Error loading config: ${e}`);
    }
}

function updateUIFromConfig() {
    if (!config) return;

    // Hide database selector if configured
    if (config.hideDatabase) {
        databaseSelector.style.display = 'none';
    } else {
        databaseSelector.style.display = 'block';
    }
}

// Databases
async function loadDatabases() {
    try {
        databases = await invoke('get_databases');
        populateDatabaseSelector();
        selectStartupDatabase();
    } catch (e) {
        setStatus(`Error loading databases: ${e}`);
    }
}

function populateDatabaseSelector() {
    databaseSelector.innerHTML = '<option value="">Select a database...</option>';

    databases.forEach(db => {
        const option = document.createElement('option');
        option.value = db;
        option.textContent = db;
        databaseSelector.appendChild(option);
    });
}

function selectStartupDatabase() {
    if (databases.length === 0) {
        setStatus('No game databases found');
        return;
    }

    let dbToSelect = null;
    const startupDb = config?.startupDatabase?.toLowerCase() || 'first';

    switch (startupDb) {
        case 'first':
            dbToSelect = databases[0];
            break;
        case 'last':
            dbToSelect = databases[databases.length - 1];
            break;
        case 'random':
            dbToSelect = databases[Math.floor(Math.random() * databases.length)];
            break;
        default:
            // Custom database name
            dbToSelect = databases.find(d => d.toLowerCase() === config.startupDatabase.toLowerCase());
            if (!dbToSelect) dbToSelect = databases[0];
            break;
    }

    if (dbToSelect) {
        databaseSelector.value = dbToSelect;
        onDatabaseChange();
    }
}

async function onDatabaseChange() {
    const filename = databaseSelector.value;
    if (!filename) {
        gamesList.innerHTML = '';
        return;
    }

    try {
        currentDatabase = await invoke('load_game_database', { filename });
        renderGames();
        updateArtwork(currentDatabase.collectionArtworkPath);
        updateManualButton();
        updateWindowTitle();
        setStatus(`Loaded: ${currentDatabase.name}`);
    } catch (e) {
        setStatus(`Error loading database: ${e}`);
    }
}

// Games
function renderGames() {
    gamesList.innerHTML = '';

    if (!currentDatabase || !currentDatabase.games) return;

    currentDatabase.games.forEach((game, index) => {
        const gameItem = document.createElement('div');
        gameItem.className = 'game-item';
        gameItem.innerHTML = `
            <span class="game-name">${escapeHtml(game.name)}</span>
            <button class="play-btn" onclick="launchGame(${index})">Play</button>
        `;

        // Hover events for artwork
        gameItem.addEventListener('mouseenter', () => {
            if (config?.showGameArtOnHover && game.artworkPath) {
                updateArtwork(game.artworkPath);
            }
        });

        gameItem.addEventListener('mouseleave', () => {
            if (config?.showGameArtOnHover && currentDatabase) {
                updateArtwork(currentDatabase.collectionArtworkPath);
            }
        });

        gamesList.appendChild(gameItem);
    });
}

async function launchGame(index) {
    if (!currentDatabase) return;

    const game = currentDatabase.games[index];
    setStatus(`Launching: ${game.name}`);

    try {
        await invoke('launch', { gameIndex: index, database: currentDatabase });

        if (closeAfterLaunch.checked) {
            exitApp();
        }
    } catch (e) {
        setStatus(`Failed to launch: ${e}`);
    }
}

// Artwork
function updateArtwork(path) {
    if (path) {
        artwork.src = convertFilePath(path);
        artwork.style.display = 'block';
        noArtwork.style.display = 'none';

        artwork.onerror = () => {
            artwork.style.display = 'none';
            noArtwork.style.display = 'block';
        };
    } else {
        artwork.style.display = 'none';
        noArtwork.style.display = 'block';
    }
}

function convertFilePath(path) {
    // Convert file path to Tauri asset URL
    return window.__TAURI__.tauri.convertFileSrc(path);
}

// Manual
function updateManualButton() {
    const hasManual = currentDatabase && currentDatabase.manualPath;
    manualBtn.disabled = !hasManual;
}

async function openManual() {
    if (!currentDatabase || !currentDatabase.manualPath) return;

    try {
        await invoke('open_manual', { path: currentDatabase.manualPath });
        setStatus('Opening manual...');
    } catch (e) {
        setStatus(`Failed to open manual: ${e}`);
    }
}

// Window
function updateWindowTitle() {
    if (!config || !currentDatabase) return;

    let title = config.titleWindowFormat || '%APP - %GAME';
    title = title.replace(/%APP/gi, 'Sierra Classics Launcher');
    title = title.replace(/%VER/gi, '2.0.0');
    title = title.replace(/%GAME/gi, currentDatabase.name || '');

    document.title = title;
}

// Preferences
function showPreferences() {
    document.getElementById('preferences-modal').classList.add('active');
    loadPreferencesForm();
}

function hidePreferences() {
    document.getElementById('preferences-modal').classList.remove('active');
}

function loadPreferencesForm() {
    if (!config) return;

    document.getElementById('pref-dosbox-path').value = config.dosboxPath || '';
    document.getElementById('pref-scummvm-path').value = config.scummvmPath || '';
    document.getElementById('pref-xml-path').value = config.xmlDatabasePath || '';
    document.getElementById('pref-art-path').value = config.gameArtPath || '';
    document.getElementById('pref-title-format').value = config.titleWindowFormat || '';

    const startupDb = (config.startupDatabase || 'first').toLowerCase();
    const startupSelect = document.getElementById('pref-startup-db');

    if (['first', 'last', 'random'].includes(startupDb)) {
        startupSelect.value = startupDb;
        document.getElementById('custom-db-group').style.display = 'none';
    } else {
        startupSelect.value = 'custom';
        document.getElementById('pref-custom-db').value = config.startupDatabase;
        document.getElementById('custom-db-group').style.display = 'block';
    }

    document.getElementById('pref-close-on-save').checked = config.closeOnSave || false;
    document.getElementById('pref-hide-db').checked = config.hideDatabase || false;
    document.getElementById('pref-remember-db').checked = config.rememberLastDatabase !== false;
    document.getElementById('pref-show-art').checked = config.showGameArtOnHover !== false;

    // Populate database selector in preferences
    const dbSelector = document.getElementById('pref-db-selector');
    dbSelector.innerHTML = '';
    databases.forEach(db => {
        const option = document.createElement('option');
        option.value = db;
        option.textContent = db;
        dbSelector.appendChild(option);
    });

    if (currentDatabase) {
        dbSelector.value = currentDatabase.filename;
        loadDatabaseEditor();
    }
}

function loadDatabaseEditor() {
    if (!currentDatabase) return;

    document.getElementById('pref-db-name').value = currentDatabase.name || '';
    document.getElementById('pref-db-default-path').value = currentDatabase.defaultPath || '';
    document.getElementById('pref-db-manual').value = currentDatabase.manualPath || '';
    document.getElementById('pref-db-artwork').value = currentDatabase.collectionArtworkPath || '';
}

async function savePreferences() {
    const startupSelect = document.getElementById('pref-startup-db');
    let startupDb = startupSelect.value;
    if (startupDb === 'custom') {
        startupDb = document.getElementById('pref-custom-db').value;
    }

    const newConfig = {
        startupDatabase: startupDb,
        dosboxPath: document.getElementById('pref-dosbox-path').value,
        scummvmPath: document.getElementById('pref-scummvm-path').value,
        xmlDatabasePath: document.getElementById('pref-xml-path').value,
        gameArtPath: document.getElementById('pref-art-path').value,
        titleWindowFormat: document.getElementById('pref-title-format').value,
        closeOnSave: document.getElementById('pref-close-on-save').checked,
        hideDatabase: document.getElementById('pref-hide-db').checked,
        rememberLastDatabase: document.getElementById('pref-remember-db').checked,
        showGameArtOnHover: document.getElementById('pref-show-art').checked
    };

    try {
        await invoke('update_config', { newConfig });
        config = newConfig;
        updateUIFromConfig();
        setStatus('Preferences saved');

        if (config.closeOnSave) {
            hidePreferences();
        }
    } catch (e) {
        setStatus(`Error saving preferences: ${e}`);
    }
}

function setupStartupDbChange() {
    document.getElementById('pref-startup-db').addEventListener('change', (e) => {
        const customGroup = document.getElementById('custom-db-group');
        customGroup.style.display = e.target.value === 'custom' ? 'block' : 'none';
    });
}

// About
function showAbout() {
    document.getElementById('about-modal').classList.add('active');
}

function hideAbout() {
    document.getElementById('about-modal').classList.remove('active');
}

// Tabs
function setupTabs() {
    document.querySelectorAll('.tab').forEach(tab => {
        tab.addEventListener('click', () => {
            // Remove active from all tabs and contents
            document.querySelectorAll('.tab').forEach(t => t.classList.remove('active'));
            document.querySelectorAll('.tab-content').forEach(c => c.classList.remove('active'));

            // Add active to clicked tab and its content
            tab.classList.add('active');
            const tabId = `tab-${tab.dataset.tab}`;
            document.getElementById(tabId).classList.add('active');
        });
    });
}

// Utility
function setStatus(message) {
    statusMessage.textContent = message;
}

function escapeHtml(text) {
    const div = document.createElement('div');
    div.textContent = text;
    return div.innerHTML;
}

async function reloadDatabases() {
    await loadConfig();
    await loadDatabases();
    setStatus('Databases reloaded');
}

async function exitApp() {
    // Save last database if configured
    if (config?.rememberLastDatabase && databaseSelector.value) {
        config.startupDatabase = databaseSelector.value;
        try {
            await invoke('update_config', { newConfig: config });
        } catch (e) {
            console.error('Failed to save config on exit:', e);
        }
    }

    // Close the window
    window.__TAURI__.window.getCurrent().close();
}
