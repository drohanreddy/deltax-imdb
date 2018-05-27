import {Component, OnInit} from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-producer',
    templateUrl: './producer.component.html',
    styleUrls: ['producer.component.css']
})
export class ProducerComponent implements OnInit {
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