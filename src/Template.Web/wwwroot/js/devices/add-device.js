document.addEventListener('DOMContentLoaded', function () {
    var _a;
    const deviceTypeSelect = document.getElementById('DeviceType');
    const dynamicFieldsContainer = document.getElementById('dynamic-fields');
    const warrantyStartDateInput = document.getElementById('WarrantyStartDate');
    const warrantyEndDateInput = document.getElementById('WarrantyEndDate');
    // Imposta i valori di default per Warranty Start Date e Warranty End Date
    const today = new Date();
    const defaultStartDate = new Date(today.setDate(today.getDate() - 10));
    const defaultEndDate = new Date(defaultStartDate);
    defaultEndDate.setFullYear(defaultEndDate.getFullYear() + 4);
    warrantyStartDateInput.value = defaultStartDate.toISOString().split('T')[0];
    warrantyEndDateInput.value = defaultEndDate.toISOString().split('T')[0];
    // Imposta il valore minimo di Warranty End Date in base a Warranty Start Date
    warrantyStartDateInput.addEventListener('change', function () {
        warrantyEndDateInput.min = warrantyStartDateInput.value;
        if (new Date(warrantyEndDateInput.value) < new Date(warrantyStartDateInput.value)) {
            warrantyEndDateInput.value = warrantyStartDateInput.value;
        }
    });
    // Imposta il valore minimo iniziale di Warranty End Date
    warrantyEndDateInput.min = warrantyStartDateInput.value;
    deviceTypeSelect.addEventListener('change', function () {
        const selectedType = deviceTypeSelect.value;
        dynamicFieldsContainer.innerHTML = '';
        if (selectedType === 'Laptop' || selectedType === 'Desktop-PC') {
            dynamicFieldsContainer.innerHTML += `
                <div class="form-group mb-3">
                    <label for="Model">Model</label>
                    <input type="text" class="form-control" id="Model" name="Model" required />
                </div>
                <div class="form-group mb-3">
                    <label for="DiskType">Disk Type</label>
                    <select class="form-control" id="DiskType" name="DiskType" required>
                        <option value="" disabled selected>Choose an option</option>
                        <option value="HDD">HDD</option>
                        <option value="SSD">SSD</option>
                    </select>
                </div>
                <div class="form-group mb-3">
                    <label for="DiskSize">Disk Size</label>
                    <select class="form-control" id="DiskSize" name="DiskSize" required>
                        <option value="" disabled selected>Choose an option</option>
                        <option value="128">128</option>
                        <option value="256">256</option>
                        <option value="512">512</option>
                        <option value="1T">1T</option>
                    </select>
                </div>
                <div class="form-group mb-3">
                    <label for="RamSize">Ram Size</label>
                    <select class="form-control" id="RamSize" name="RamSize" required>
                        <option value="" disabled selected>Choose an option</option>
                        <option value="4">4</option>
                        <option value="8">8</option>
                        <option value="16">16</option>
                        <option value="32">32</option>
                        <option value="64">64</option>
                    </select>
                </div>
                <div class="form-group mb-3">
                    <label for="ProcessorType">Processor Type</label>
                    <input type="text" class="form-control" id="ProcessorType" name="ProcessorType" required />
                </div>
            `;
        }
        else if (selectedType === 'Phone') {
            dynamicFieldsContainer.innerHTML += `
                <div class="form-group mb-3">
                    <label for="Model">Model</label>
                    <input type="text" class="form-control" id="Model" name="Model" required />
                </div>
                <div class="form-group mb-3">
                    <label for="DiskSize">Disk Size</label>
                    <select class="form-control" id="DiskSize" name="DiskSize" required>
                        <option value="" disabled selected>Choose an option</option>
                        <option value="64">64</option>
                        <option value="128">128</option>
                        <option value="256">256</option>
                    </select>
                </div>
            `;
        }
    });
    (_a = document.getElementById("addDeviceForm")) === null || _a === void 0 ? void 0 : _a.addEventListener("submit", function (event) {
        event.preventDefault();
        const form = event.target;
        const formData = new FormData(form);
        const deviceType = formData.get('DeviceTypeName');
        let valid = true;
        // Check required fields
        const requiredFields = form.querySelectorAll('input[required], select[required]');
        requiredFields.forEach(field => {
            var _a;
            const input = field;
            if (!input.value) {
                alert(`Compila il campo ${(_a = input.previousElementSibling) === null || _a === void 0 ? void 0 : _a.textContent}`);
                valid = false;
                return;
            }
        });
        if (!valid)
            return;
        // Additional checks based on device type
        if (deviceType === 'Laptop' || deviceType === 'Desktop-PC') {
            const model = formData.get('Model');
            const diskType = formData.get('DiskType');
            const diskSize = formData.get('DiskSize');
            const ramSize = formData.get('RamSize');
            const processorType = formData.get('ProcessorType');
            if (!model || !diskType || !diskSize || !ramSize || !processorType) {
                alert('Compila tutti i campi per il dispositivo selezionato');
                return;
            }
        }
        else if (deviceType === 'Phone') {
            const model = formData.get('Model');
            const diskSize = formData.get('DiskSize');
            if (!model || !diskSize) {
                alert('Compila tutti i campi per il dispositivo selezionato');
                return;
            }
        }
        // Submit the form if all checks pass
        form.submit();
    });
});
//# sourceMappingURL=add-device.js.map