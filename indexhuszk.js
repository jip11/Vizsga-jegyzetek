import { PrismaClient } from "./generated/prisma/client";
import express from "express";

const prisma = new PrismaClient();

const app = express();

app.use(express.json());
app.use(express.urlencoded());

app.get("/api/diakok", async (req, res) => {
    const data = await prisma.diak.findMany({
        include: {
            verseny: true,
        },
    });

    res.status(200).json(data);
});

app.post("/api/diakok", async (req, res) =>{
    const { nev, iskola, szazalek, verseny_id } = req.body

    try {

    await prisma.diak.create({
        data:{
            nev: nev,
            iskola: iskola,
            szazalek: szazalek,
            verseny_id: verseny_id,
        },
    });

    res.status(201).send("Az adat sikeresen létrejött");
} catch (err){
    res.status(400).send("Az adat létrehozása sikertelen");
}
});

app.put("/api/diakok/:id", async (req, res) =>{
    const id = Number(req.params.id);
    const { nev, szazalek } = req.body;

    try {
      const data = await prisma.diak.update({
            where:{
                id: id,
            },
            data: {
                nev: nev,
                szazalek: szazalek,
            }
        });

        res.status(200).json({id: data.id});
    } catch (error) {
        res.status(400).send("Az adatok módósítása sikertelen")
    }
});

app.delete("/api/diakok", async (req, res) => {
    const id = Number(req.query.id);

    try{
        const data = await prisma.diak.delete({
            where:{
                id: id,
            },
        });

        res.status(204).send();
    }catch (error) {
        res.status(400).send("Sikertelen törlés");
    }
});

app.listen(3300, () => {
    console.log("Megy")
})
