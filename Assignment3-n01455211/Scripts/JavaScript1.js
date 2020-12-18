// AJAX for teacher Add can go in here!
// This file is connected to the project via Shared/_Layout.cshtml


function AddTeacher() {

	//goal: send a request which looks like this:
	//POST : http://localhost:51326/api/TeacherData/AddTeacher
	//with POST data of teacher first and last name, employee number, per hour salary.

	var URL = "http://localhost:51326/api/TeacherData/AddTeacher/";

	var rq = new XMLHttpRequest();
	// where is this request sent to?
	// is the method GET or POST?
	// what should we do with the response?

	var TeacherFname = document.getElementById('TeacherFname').value;
	var TeacherLname = document.getElementById('TeacherLname').value;
	var EmployeeNumber = document.getElementById('EmployeeNumber').value;
	var Salary = document.getElementById('Salary').value;



	var TeacherData = {
		"TeacherFname": TeacherFname,
		"TeacherLname": TeacherLname,
		"EmployeeNumber": EmployeeNumber,
		"Salary": Salary
	};


	rq.open("POST", URL, true);
	rq.setRequestHeader("Content-Type", "application/json");
	rq.onreadystatechange = function () {
		//ready state should be 4 AND status should be 200
		if (rq.readyState == 4 && rq.status == 200) {
			//request is successful and the request is finished

			//nothing to render, the method returns nothing.


		}

	}
	//POST information sent through the .send() method
	rq.send(JSON.stringify(TeacherData));

}


// AJAX for Course Add can go in here!
// This file is connected to the project via Shared/_Layout.cshtml


function AddClass() {

	//goal: send a request which looks like this:
	//POST : http://localhost:51326/api/ClassData/AddClass
	//with POST data of course code, course name, start and finish date, teacher id

	var URL = "http://localhost:51326/api/ClassData/AddClass/";

	var rq = new XMLHttpRequest();
	// where is this request sent to?
	// is the method GET or POST?
	// what should we do with the response?

	var Classcode = document.getElementById('Classcode').value;
	var Classname = document.getElementById('Classname').value;
	var Startdate = document.getElementById('Startdate').value;
	var Finishdate = document.getElementById('Finishdate').value;
	var Teacherid = document.getElementById('Teacherid').value;



	var ClassData = {
		"Classcode": Classcode,
		"Classname": Classname,
		"Startdate": Startdate,
		"Finishdate": Finishdate,
		"Teacherid": Teacherid
	};


	rq.open("POST", URL, true);
	rq.setRequestHeader("Content-Type", "application/json");
	rq.onreadystatechange = function () {
		//ready state should be 4 AND status should be 200
		if (rq.readyState == 4 && rq.status == 200) {
			//request is successful and the request is finished

			//nothing to render, the method returns nothing.


		}

	}
	//POST information sent through the .send() method
	rq.send(JSON.stringify(ClassData));

}