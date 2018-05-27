import {Component, OnInit} from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-actor',
    templateUrl: './actor.component.html',
    styleUrls: ['actor.component.css']
})
export class ActorComponent implements OnInit {
    actor : {
        id : number
    }
    constructor(private route: ActivatedRoute) {
        this.actor = {
            id: this.route.snapshot.params["id"],
        }

    }
    ngOnInit(){

    }
}