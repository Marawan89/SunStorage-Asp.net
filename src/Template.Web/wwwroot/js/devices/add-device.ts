document.getElementById("addDeviceForm")?.addEventListener("submit", async (event) => {
    event.preventDefault();

    const formData = new FormData(event.target as HTMLFormElement);

    try {
        const response = await fetch('/api/devices', {
            method: 'POST',
            body: JSON.stringify(Object.fromEntries(formData)),
            headers: {
                'Content-Type': 'application/json'
            }
        });

        if (response.ok) {
            alert('Device added successfully!');
            window.location.href = '/admin/devices';
        } else {
            alert('Failed to add device');
        }
    } catch (error) {
        console.error('Error adding device:', error);
    }
});
