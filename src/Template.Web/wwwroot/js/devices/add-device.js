var _a;
(_a = document.getElementById("addDeviceForm")) === null || _a === void 0 ? void 0 : _a.addEventListener("submit", async (event) => {
    event.preventDefault();
    const formData = new FormData(event.target);
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
        }
        else {
            alert('Failed to add device');
        }
    }
    catch (error) {
        console.error('Error adding device:', error);
    }
});
//# sourceMappingURL=add-device.js.map