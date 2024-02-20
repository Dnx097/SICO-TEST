// StudentList.js
import React from 'react';
import { Button, Form, Table } from 'react-bootstrap';

export default function StudentList({ students, openModal, searchTerm, handleSearch }) {
    const filteredStudents = students.filter(student => {
        const searchTermLowerCase = searchTerm.toLowerCase();

        const nombreLowerCase = student.nombresEstudiante.toLowerCase();
        const otroAtributoLowerCase = student.apellidosEstudiante.toLowerCase();
        const tercerAtributoLowerCase = student.correo.toLowerCase();
        // Agrega más atributos según sea necesario

        return nombreLowerCase.includes(searchTermLowerCase) ||
            otroAtributoLowerCase.includes(searchTermLowerCase) ||
            tercerAtributoLowerCase.includes(searchTermLowerCase);
    });

    return (
        <div>

            <Form.Group controlId="search">
                <Form.Label className='mx-2'>Buscar Estudiantes:</Form.Label>
                <Form.Control
                    className='ml-2'
                    type="text"
                    placeholder="Ingrese el nombre, apellido o correo del estudiante"
                    value={searchTerm}
                    onChange={(e) => handleSearch(e.target.value)}
                />
            </Form.Group>

            <hr />

            <Table striped bordered hover>
                <thead>
                    <tr>
                        <th>Nombres</th>
                        <th>Apellidos</th>
                        <th>Edad</th>
                        <th>Telefono</th>
                        <th>Correo</th>
                    </tr>
                </thead>
                <tbody>
                    {filteredStudents.map(student => (

                        <tr key={student.idEstudiante}>
                            <td>{student.nombresEstudiante}</td>
                            <td>{student.apellidosEstudiante}</td>
                            <td>{student.edad}</td>
                            <td>{student.telefono}</td>
                            <td>{student.correo}</td>
                            <td style={{ display: 'flex', justifyContent: 'center' }}>
                                <Button type='button' variant="primary" onClick={() => openModal(student)}>Administrar Cursos</Button>
                            </td>
                        </tr>
                    ))}

                </tbody>
            </Table>

        </div>
    );
};

