// assign-device.ts

// Funzione per inviare i dati del form in modo asincrono usando Fetch API
async function assignDevice(event: Event) {
    event.preventDefault(); // Evita il comportamento predefinito del form (refresh della pagina)

    // Ottieni l'ID del dispositivo dall'attributo data-* del pulsante
    const deviceId = (event.currentTarget as HTMLElement)?.getAttribute("data-device-id");
    if (!deviceId) {
        showErrorMessage("Device ID is missing.");
        return;
    }

    // Recupera il form e crea un oggetto FormData
    const form = document.getElementById("assignDeviceForm") as HTMLFormElement;
    const formData = new FormData(form);

    // Crea un oggetto per i dati del form
    const data = {
        Nome: formData.get("Nome"),
        Cognome: formData.get("Cognome"),
        Email: formData.get("Email")
    };

    try {
        // Effettua una chiamata POST al server con i dati del form
        const formData = new FormData(form);
        const response = await fetch(`/Admin/Users/AssignDevice?id=${deviceId}`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json",
                "RequestVerificationToken": (form.querySelector('input[name="__RequestVerificationToken"]') as HTMLInputElement).value
            },
            body: JSON.stringify(data)
        });

        // Controlla se la risposta è andata a buon fine
        if (response.ok) {
            const result = await response.json();
            showSuccessMessage("Device assigned successfully!");
            resetForm(form);
        } else {
            // Se la risposta non è stata un successo, mostra l'errore
            const errorText = await response.text();
            showErrorMessage(`Failed to assign device: ${errorText}`);
        }
    } catch (error) {
        // Gestione degli errori della chiamata fetch
        showErrorMessage(`An error occurred: ${error}`);
    }
}

// Funzione per mostrare un messaggio di successo
function showSuccessMessage(message: string) {
    const successDiv = document.createElement("div");
    successDiv.className = "alert alert-success alert-dismissible fade show";
    successDiv.role = "alert";
    successDiv.innerHTML = `
        ${message}
        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
    `;
    document.body.appendChild(successDiv);
}

// Funzione per mostrare un messaggio di errore
function showErrorMessage(message: string) {
    const errorDiv = document.createElement("div");
    errorDiv.className = "alert alert-danger alert-dismissible fade show";
    errorDiv.role = "alert";
    errorDiv.innerHTML = `
        ${message}
        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
    `;
    document.body.appendChild(errorDiv);
}

// Funzione per resettare il form
function resetForm(form: HTMLFormElement) {
    form.reset();
}

// Aggiungi un event listener per gestire il click sul pulsante "Assign Device"
document.querySelectorAll('.assign-device-btn').forEach(button => {
    button.addEventListener('click', assignDevice);
});
