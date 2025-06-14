const targetSpan = document.querySelector('#PageDescription');
if (targetSpan && targetSpan.textContent.trim() === '- Mods and Modding Resources by the WuWa Modding Community.') {
  targetSpan.textContent = 'NEMESIS INTEROGATION STARTED';
}

// Feature 2: Add Nemesis Downloader button next to every Manual Download button in DownloadOptions
function addNemesisDownloaderButtonsForAll() {
  // Find all DownloadOptions divs
  const downloadDivs = document.querySelectorAll('div.DownloadOptions');
  downloadDivs.forEach(downloadDiv => {
    // Find all Manual Download buttons in this div
    const manualBtns = Array.from(downloadDiv.querySelectorAll('a.GreenColor')).filter(a => a.textContent.includes('Manual Download') || a.textContent.includes('Download'));
    manualBtns.forEach(manualBtn => {
      // Check if a Nemesis Downloader already exists for this file
      const alreadyExists = Array.from(downloadDiv.querySelectorAll('a.GreenColor')).some(a => a.textContent.includes('Nemesis Downloader'));
      if (!alreadyExists) {
        // Modify the existing button
        const span = manualBtn.querySelector('span');
        if (span) span.textContent = 'Nemesis Downloader';
        const href = manualBtn.getAttribute('href');
        const match = href && href.match(/#FileInfo_(\d+)/);
        if (match) {
          manualBtn.setAttribute('href', `https://gamebanana.com/dl/${match[1]}`);
        } else if (href && href.startsWith('https://gamebanana.com/dl/')) {
          // Direct download link
          manualBtn.setAttribute('href', href);
        }
        // Add click event listener to the modified button
        manualBtn.addEventListener('click', function(e) {
          e.preventDefault();
          const originalText = manualBtn.textContent;
          manualBtn.textContent = 'Loading...';
          manualBtn.disabled = true;
          const nemesisUrl = manualBtn.getAttribute('href');
          openWithNemesisLocalServerOrAlert(nemesisUrl);
          setTimeout(() => {
            manualBtn.textContent = originalText;
            manualBtn.disabled = false;
          }, 1000);
        });
      }
    });
  });
}

function openWithNemesisLocalServerOrAlert(url) {
  fetch('http://localhost:14580/?url=' + encodeURIComponent(url), { method: 'GET' })
    .then(res => {
      if (res.ok) {
        // Optionally, show a success message or do nothing
        // res.text().then(text => alert(text)); // Uncomment to show server message
        return;
      }
      // Only show alert if server responds with error
      throw new Error('App responded with error');
    })
}

if (window.location.pathname.startsWith('/mods/')) {
  // Try immediately
  addNemesisDownloaderButtonsForAll();
  // Also observe for dynamic content
  const observer = new MutationObserver(addNemesisDownloaderButtonsForAll);
  observer.observe(document.body, { childList: true, subtree: true });
} 