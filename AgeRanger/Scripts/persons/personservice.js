app.service("personService", function ($http) {

    //Get all persons
    this.getPersons = function () {
        return $http.get("Person/GetAllPersons");
    };

    //Get a given person
    this.getPerson = function (personId) {
        var response = $http({
            method: "post",
            url: "Person/GetPerson",
            params: {
                id: JSON.stringify(personId)
            }
        });
        return response;
    }

    // Update a person
    this.updatePerson = function (person) {
        var response = $http({
            method: "post",
            url: "Person/UpdatePerson",
            data: JSON.stringify(person),
            dataType: "json"
        });
        return response;
    }

    // Add a person
    this.addPerson = function (person) {
        var response = $http({
            method: "post",
            url: "Person/AddPerson",
            data: JSON.stringify(person),
            dataType: "json"
        });
        return response;
    }

    //Delete a person
    this.deletePerson = function (personId) {
        var response = $http({
            method: "post",
            url: "Person/DeletePerson",
            params: {
                id: JSON.stringify(personId)
            }
        });
        return response;
    }
});