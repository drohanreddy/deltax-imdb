export interface AllMoviesData {
    movieID:       number;
    movieName:     string;
    yearOfRelease: number;
    moviePoster:   string;
    plot:           string;
    producerID:    number;
    producerName:  string;
    actors:        Actor[];
}

export interface Actor {
    actorID:   number;
    actorName: string;
}

export interface Producer {
    producerID:   number;
    producerName: string;
}