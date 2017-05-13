'use strict';

import RestService from '../shared/rest.service';

class PeopleService {

    constructor() {
        this._rest = new RestService();
    }

    getPeople() {
        return this._rest.get('/api/data')
            .then(function (response) {
                return response.data;
            });
    }

    getOrder(orderId) {
        return { id: 1, name: 'Order 1' }
    }
}
export default PeopleService;