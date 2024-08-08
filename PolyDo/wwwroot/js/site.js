document.addEventListener('DOMContentLoaded', () => {
    document.querySelectorAll('.dashboard-buttons div').forEach(button => {
        button.addEventListener('click', () => {
            window.location.href = `/${button.getAttribute('data-url')}`;
        });
    });

    document.querySelector('.round-icon').addEventListener('click', () => {
        alert('Personal info clicked!');
    });
});
