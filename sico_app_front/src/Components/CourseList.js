// CourseList.js
import React from 'react';
import { Table, Button } from 'react-bootstrap';

const CourseList = ({ courses, selectedStudent, addCourseToStudent, removeCourseFromStudent }) => {
  const studentCourses = selectedStudent ? selectedStudent.estudianteXCursos : [];

  //   console.log(selectedStudent)

  const isCourseAdded = (courseId) => {
    // console.log(studentCourses.includes(courseId), "ACA")
    return studentCourses.includes(courseId);
  };

  return (
    <Table striped bordered hover>
      <thead>
        <tr>
          <th>Nombre del Curso</th>
          <th style={{ display: 'flex', justifyContent: 'flex-end' }}>Acción</th>
        </tr>
      </thead>
      <tbody>
        {courses.map(course => (
          <tr key={course.idCurso} >
            <td style={{ backgroundColor: isCourseAdded(course.idCurso) ? 'red' : 'green' }}>{course.nombreCurso}</td>
            <td style={{ display: 'flex', justifyContent: 'flex-end' }}>
              {!isCourseAdded(course.idCurso) && (
                <Button variant="success" onClick={() => addCourseToStudent(course.idCurso)}>Agregar</Button>
              )}
              {isCourseAdded(course.idCurso) && (
                <Button variant="danger" onClick={() => removeCourseFromStudent(course.idCurso, selectedStudent.idEstudiante)}>Quitar</Button>
              )}
            </td>
          </tr>
        ))}
      </tbody>
    </Table>
  );
};

export default CourseList;
