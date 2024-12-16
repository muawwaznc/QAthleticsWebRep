
function downloadFileFromUrl(url, fileName) {
    const link = document.createElement('a');
    link.href = url;
    link.download = fileName;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}

/* Preloader */
window.onload = function () {
    const preloader = document.querySelector('.preloader');
    if (preloader) {
        preloader.style.transition = 'opacity 1s ease';
        preloader.style.opacity = '0';
        setTimeout(() => preloader.style.display = 'none', 1000);
    }
};

/* DOM Content Loaded */
document.addEventListener('DOMContentLoaded', function () {

    /* Template navigation */
    const navLinks = document.querySelectorAll('.navbar-default a, #home a, #overview a');

    navLinks.forEach(link => {
        link.addEventListener('click', function (event) {
            event.preventDefault();
            const target = document.querySelector(this.getAttribute('href'));
            if (target) {
                window.scrollTo({
                    top: target.offsetTop - 49,
                    behavior: 'smooth'
                });
            }
        });
    });

    /* Hide mobile menu after clicking a link */
    const navbarLinks = document.querySelectorAll('.navbar-collapse a');
    const navbarCollapse = document.querySelector('.navbar-collapse');

    navbarLinks.forEach(link => {
        link.addEventListener('click', function () {
            if (navbarCollapse) {
                navbarCollapse.classList.remove('show');
            }
        });
    });

    /* Parallax Section */
    function initParallax() {
        const parallaxSections = [
            { id: '#home', speed: 0.1 },
            { id: '#overview', speed: 0.3 },
            { id: '#trainer', speed: 0.2 },
            { id: '#newsletter', speed: 0.3 },
            { id: '#blog', speed: 0.1 },
            { id: '#price', speed: 0.2 },
            { id: '#testimonial', speed: 0.2 },
        ];

        parallaxSections.forEach(section => {
            const element = document.querySelector(section.id);
            if (element) {
                window.addEventListener('scroll', () => {
                    const offset = window.scrollY * section.speed;
                    element.style.backgroundPosition = `50% ${offset}px`;
                });
            }
        });
    }
    initParallax();

    /* Home Slider Section */
    const backstretchImages = [
        "images/home-bg-slider-img1.jpg",
        "images/home-bg-slider-img2.jpg"
    ];

    const homeElement = document.querySelector('#home');

    if (homeElement) {
        let currentIndex = 0;

        const changeBackground = () => {
            // Preload the image
            const img = new Image();
            img.src = backstretchImages[currentIndex];

            img.onload = () => {
                // Apply only the background-image
                //homeElement.style.backgroundImage = `url(${img.src})`;
                console.log(`Background updated to: ${img.src}`);
                currentIndex = (currentIndex + 1) % backstretchImages.length;
            };

            img.onerror = () => {
                console.error(`Failed to load image: ${img.src}`);
            };
        };

        changeBackground();
        setInterval(changeBackground, 2000); // Change every 2 seconds
    }

    /* Owl Carousel */
    const owlTestimonial = document.querySelector("#owl-testimonial");
    if (owlTestimonial) {
        let index = 0;
        const items = owlTestimonial.children;
        const totalItems = items.length;

        const autoPlayCarousel = () => {
            items[index].style.display = 'none';
            index = (index + 1) % totalItems;
            items[index].style.display = 'block';
        };

        for (let i = 1; i < totalItems; i++) {
            items[i].style.display = 'none';
        }

        setInterval(autoPlayCarousel, 6000);
    }

    /* WOW Animation */
    const wowElements = document.querySelectorAll('.wow');
    if (wowElements.length > 0 && !/Mobi/.test(navigator.userAgent)) {
        wowElements.forEach(el => {
            const observer = new IntersectionObserver(entries => {
                entries.forEach(entry => {
                    if (entry.isIntersecting) {
                        el.classList.add('animate');
                        observer.unobserve(el);
                    }
                });
            });
            observer.observe(el);
        });
    }
});
