'use strict';

import axios from 'axios';

class RestService {

    constructor() {
        this._baseUrl = window.location.origin;
    }

    get(url) {
        return axios.get(this._baseUrl + url);
    }
}
export default RestService;