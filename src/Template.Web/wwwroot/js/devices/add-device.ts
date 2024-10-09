document.addEventListener('DOMContentLoaded', function () {
    const deviceTypeSelect = document.getElementById('DeviceTypeName') as HTMLSelectElement;
    const warrantyStartDateInput = document.getElementById('WarrantyStartDate') as HTMLInputElement;
    const warrantyEndDateInput = document.getElementById('WarrantyEndDate') as HTMLInputElement;

    // Imposta i valori di default per Warranty Start Date e Warranty End Date
    const today = new Date();
    const defaultStartDate = new Date(today.setDate(today.getDate() - 10));
    const defaultEndDate = new Date(defaultStartDate);
    defaultEndDate.setFullYear(defaultEndDate.getFullYear() + 4);

    warrantyStartDateInput.value = defaultStartDate.toISOString().split('T')[0];
    warrantyEndDateInput.value = defaultEndDate.toISOString().split('T')[0];

    warrantyStartDateInput.addEventListener('change', function () {
        warrantyEndDateInput.min = warrantyStartDateInput.value;
        if (new Date(warrantyEndDateInput.value) < new Date(warrantyStartDateInput.value)) {
            warrantyEndDateInput.value = warrantyStartDateInput.value;
        }
    });

    warrantyEndDateInput.min = warrantyStartDateInput.value
});
