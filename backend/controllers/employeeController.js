const { PrismaClient } = require("@prisma/client");
const prisma = new PrismaClient();

exports.getEmployees = async (req, res) => {
    const result = await prisma.$queryRaw`
      SELECT e.id AS employee_id, e.name AS employee_name, e.age, e.salary, 
             ed.employee_id, ed.department_id, 
             d.id AS department_id, d.name AS department_name
      FROM employees e
      JOIN employee_department ed ON e.id = ed.employee_id
      JOIN departments d ON ed.department_id = d.id
    `;
  
    res.json(result);
};