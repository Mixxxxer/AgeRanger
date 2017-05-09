app.controller("personCtrl", function ($scope, personService) {
    $scope.divChange = false;
    getAllPersons();
    
    function getAllPersons() {
        var getPersonData = personService.getPersons();
        getPersonData.then(function (person) {
            $scope.persons = person.data;
        }, function (data) {
            debugger;
            alert("Error retrieving records from controller");
        });
    }

    $scope.editPerson = function (person) {
        var getPersonData = personService.getPerson(person.Id);
        getPersonData.then(function (current) {
            $scope.person = current.data;
            $scope.personId = person.Id;
            $scope.personFirstName = person.FirstName;
            $scope.personLastName = person.LastName;
            $scope.personAge = person.Age;
            $scope.personAgeRangeDescription = person.AgeRangeDescription;
            $scope.Action = "Update";
            $scope.divChange = true;
        }, function (data) {
            debugger;
            alert("Error getting record to edit");
        });
    }

    $scope.addupdatePerson = function () {
        var person = {
            FirstName: $scope.personFirstName,
            LastName: $scope.personLastName,
            Age: $scope.personAge,
            AgeRangeDescription: $scope.personAgeRangeDescription
        };
        var getAction = $scope.Action;

        if (getAction === "Update")
        {
            person.Id = $scope.personId;
            var updateData = personService.updatePerson(person);
            updateData.then(function () {
                getAllPersons();
                $scope.divChange = false;
            }, function (data) {
                debugger;
                alert("Error updating record");
            });
        }
        else
        {
            var addData = personService.addPerson(person);
            addData.then(function () {
                getAllPersons();
                $scope.divChange = false;
            }, function (data) {
                debugger;
                alert('Error adding record');
            });
        }
    }

    $scope.addPersonDiv = function () {
        clearFields();
        $scope.Action = "Add";
        $scope.divChange = true;
    }

    $scope.deletePerson = function (person) {
        
        var getPersonData = personService.deletePerson(person.Id);
        getPersonData.then(function () {
            getAllPersons();
        }, function (data) {
            debugger;
            alert("Error deleting record");
        });
    }

    function clearFields() {
        $scope.personId = "";
        $scope.personFirstName= "";
        $scope.personLastName = "";
        $scope.personAge = "";
        $scope.personAgeRangeDescription = "";
    }

    $scope.cancel = function () {
        $scope.divChange = false;
    };

    $scope.resetFilter = function() {
        $scope.filter = "";
        $scope.divChange = false;
    };
});