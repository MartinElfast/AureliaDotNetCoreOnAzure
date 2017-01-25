import {inject, bindable} from "aurelia-framework";

//@inject()
export class Details {

    @bindable private artist: IArtist;

    constructor() {
        
    }

    activate(artist) {
        this.artist = artist as IArtist;
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