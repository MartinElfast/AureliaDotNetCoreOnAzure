import { inject, bindable } from "aurelia-framework";
import { HttpClient } from "aurelia-fetch-client";
import { Router } from "aurelia-router";

@inject(HttpClient, Router)
export class Artists {
    @bindable public artists: Array<IArtist>;
    private router: Router;
    constructor(private http: HttpClient, router: Router) {
        this.router = router;
        this.http = http;
        this.http.configure(cfg => {
            cfg.baseUrl = 'http://bohuskonst.azurewebsites.net/';
        });
    }

    activate() {
        return this.http.fetch("api/artists").
            then(response => response.json()).
            then(data => { this.artists = data as any; });
    }
    click(artist: IArtist) {
        this.router.navigateToRoute("details", artist);
    }
}
export interface IArtist {
    id: number;
    name: string;
    cv: string;
    portraitImgUrl: string;
    frontPageImgUrl: string;
    imgUrls: Array<string>;
}