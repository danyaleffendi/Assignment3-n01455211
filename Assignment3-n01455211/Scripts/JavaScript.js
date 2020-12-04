﻿
var newTeacher = {
	TeacherFname: "",
	TeacherLname: "",
	EmployeeNumber: "",
	Salary: ""
};

var newCourse = {
	Classcode: "",
	Classname: "",
	Startdate: "",
	Finishdate: ""
};


window.onload = function () {

	var AddTeacher = document.forms.addnewteacher;
	var EmployeeNumber = /\w\d\d\d/;
	AddTeacher.onsubmit = validateTeacherForm;

	var AddCourse = document.forms.addnewcourse;
	var Classcode = /\w{4}\d{4}/;
	AddCourse.onsubmit = validateCourseForm;


	function validateTeacherForm() {

		//Assigning object property values from form submission
		AddTeacher.TeacherFname = AddTeacher.TeacherFname.value;
		AddTeacher.TeacherLname = AddTeacher.TeacherLname.value;
		AddTeacher.EmployeeNumber = AddTeacher.EmployeeNumber.value;
		AddTeacher.Salary = AddTeacher.Salary.value;


		//CHECKING FOR AN EMPTY STRING OR null VALUE in first name.
		if (AddTeacher.TeacherFname === "" || AddTeacher.TeacherFname === null) {
			alert("Please Enter First Name.");
			namefield = document.getElementById("TeacherFname");
			namefield.style.background = "red";
			namefield.focus();
			return false;
		}
		//CHECKING FOR AN EMPTY STRING OR null VALUE in last name.
		if (AddTeacher.TeacherLname === "" || AddTeacher.TeacherLname === null) {
			alert("Please Enter Last Name.");
			namefield = document.getElementById("TeacherLname");
			namefield.style.background = "red";
			namefield.focus();
			return false;
		}

		//Validating Emplyee Number format
		if (!EmployeeNumber.test(AddTeacher.EmployeeNumber)) {
			alert("Please Enter Teacher's Employee Number in Correct Format.")
			idfield = document.getElementById("EmployeeNumber");
			idfield.style.background = "red";
			idfield.focus();
			return false;
		}

		//CHECKING FOR AN EMPTY STRING OR null VALUE in salary.
		if (AddTeacher.Salary === "" || AddTeacher.Salary === null) {
			alert("Please Enter Per Hour Salary.")
			namefield = document.getElementById("Salary");
			namefield.style.background = "red";
			namefield.focus();
			return false;
		}


	}

	function validateCourseForm() {

		//Assigning object property values from form submission
		AddCourse.Classcode = AddCourse.Classcode.value;
		AddCourse.Classname = AddCourse.Classname.value;
		AddCourse.Startdate = AddCourse.Startdate.value;
		AddCourse.Finishdate = AddCourse.Finishdate.value;


		////Validating Course Code format.
		if (!Classcode.test(AddCourse.Classcode)) {
			alert("Please Enter Course Code in correct Format.");
			namefield = document.getElementById("Classcode");
			namefield.style.background = "red";
			namefield.focus();
			return false;
		}
		//CHECKING FOR AN EMPTY STRING OR null VALUE in Course name.
		if (AddCourse.Classname === "" || AddCourse.Classname === null) {
			alert("Please Enter Course Name.");
			namefield = document.getElementById("Classname");
			namefield.style.background = "red";
			namefield.focus();
			return false;
		}


		//CHECKING FOR AN EMPTY STRING OR null VALUE in Start Date.
		if (AddCourse.Startdate === "" || AddCourse.Startdate === null) {
			alert("Please Enter Course Start Date.")
			namefield = document.getElementById("Startdate");
			namefield.style.background = "red";
			namefield.focus();
			return false;
		}

		//CHECKING FOR AN EMPTY STRING OR null VALUE in Finish Date.
		if (AddCourse.Finishdate === "" || AddCourse.Finishdate === null) {
			alert("Please Enter Course Finish Date.")
			namefield = document.getElementById("Finishdate");
			namefield.style.background = "red";
			namefield.focus();
			return false;
		}

	}
}