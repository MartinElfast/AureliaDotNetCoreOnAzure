import { Router, RouterConfiguration } from "aurelia-router";

export class App {

    public router: Router;

    constructor() { }

    public configureRouter(config: RouterConfiguration, router: Router) {

        config.title = "Bohuskonst";

        config.map([
            { route: ["", "artists"],   moduleId: "artists",    nav: true,  title: "Artists",   name: 'artists' },
            { route: ["contact"],       moduleId: "contact",    nav: true,  title: "Contact",   name: 'contact' },
            { route: ["details"],       moduleId: "details",    nav: false, title: "Details",   name: 'details' },
        ]);

        this.router = router;
    }
    navigateToHome() {
        this.router.navigateToRoute("artists");
    }
}