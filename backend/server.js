const { PrismaClient } = require('@prisma/client')
const express = require('express')
const employeeRoute = require('./routes/employeeRoute');

const app = express()
const port = process.env.PORT || 8000;

app.use(express.json());

app.use('/api', employeeRoute);

app.get('/', (req, res) => {
    res.send('Backend szerver működik!');
  });
  
  app.listen(port, () => {
    console.log(`Szerver fut a http://localhost:${port}`);
  });