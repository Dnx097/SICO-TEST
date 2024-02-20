// App.js
import React, { useState, useEffect } from 'react';
import { Container, Row, Col } from 'react-bootstrap';
import StudentList from './Components/StudentList';
import CourseModal from './Components/CourseModal';

const App = () => {
  const [students, setStudents] = useState([]);
  const [selectedStudent, setSelectedStudent] = useState(null);
  const [courses, setCourses] = useState([]);
  const [modalIsOpen, setModalIsOpen] = useState(false);
  const [searchTerm, setSearchTerm] = useState('');

  useEffect(() => {
    // Obtener lista de estudiantes desde la API
    fetch('https://localhost:7016/api/Estudiante/ListadoTotal')
      .then(response => response.json())
      .then(data => setStudents(data))
      .catch(error => console.error('Error al obtener estudiantes:', error));

    // Obtener lista de cursos desde la API
    fetch('https://localhost:7016/api/Curso/ListadoCursos')
      .then(response => response.json())
      .then(data => setCourses(data))
      .catch(error => console.error('Error al obtener cursos:', error));
  }, []);

  const openModal = async (student) => {
    let URL = `https://localhost:7016/api/EstudianteXCurso/BuscarPorEstudianteXCurso?id=${student.idEstudiante}`

    const response = await fetch(URL);
    const data = await response.json();

    student.estudianteXCursos = data.map(item => item.idCurso);

    setSelectedStudent(student);
    setModalIsOpen(true);

  };
  const closeModal = () => {
    setSelectedStudent(null);
    setModalIsOpen(false);
  };

  const addCourseToStudent = (courseId) => {
    const requestBody = {
      "idEstudiante": selectedStudent.idEstudiante,
      "idCurso": courseId
    };

    fetch('https://localhost:7016/api/EstudianteXCurso/CrearEstudianteXCurso', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/JSON', // Indica que el cuerpo es de tipo JSON
      },
      body: JSON.stringify(requestBody),
    })
      .then(response => response.json())
      .then(data => console.log(data))
      .catch(error => console.error('Error al realizar la solicitud POST:', error));

  };

  const removeCourseFromStudent = async (courseId, studentId) => {

    const query = await fetch('https://localhost:7016/api/EstudianteXCurso/ListadoEstudianteXCurso');
    const queryData = await query.json();


    // console.log(courseId, studentId, 'PRIMERO');

    let EstudianteXCurso = queryData.filter(item => item.idCurso == courseId && item.idEstudiante ==  studentId);

    // console.log(EstudianteXCurso[0].idEstudianteXCurso, 'ID estudiante x curso');


    const URL = `https://localhost:7016/api/EstudianteXCurso/EliminarEstudianteXCurso?id=${EstudianteXCurso[0].idEstudianteXCurso}`;

    const response = await fetch(URL, { method: 'DELETE' });
    const data = await response.json();

    console.log(data);


  };



  const handleSearch = (term) => {
    setSearchTerm(term);
  };

  return (
    <Container>
      <Row>
        <Col>
          <h1>Lista de Estudiantes</h1>
          <StudentList
            students={students}
            openModal={openModal}
            searchTerm={searchTerm}
            handleSearch={handleSearch}
          />
        </Col>
      </Row>
      <CourseModal
        isOpen={modalIsOpen}
        closeModal={closeModal}
        selectedStudent={selectedStudent}
        courses={courses}
        addCourseToStudent={addCourseToStudent}
        removeCourseFromStudent={removeCourseFromStudent}
      />
    </Container>
  );
};

export default App;
