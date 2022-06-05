import { Button } from "antd";
import Table, { ColumnsType } from "antd/lib/table";
import React, { useState, useEffect } from "react";
import { CarsApi } from "../client/CarsApi";

import { Car } from "../client/types/Car";
import { CarEditor } from "../components/CarEditor";

type Props = {};

export function CarsView({}: Props) {
  const [cars, setCars] = useState<Car[]>([]);
  const [loadingDeleteCar, setLoadingDeleteCar] = useState(false);
  const [carsEditorActive, setCarsEditorActive] = useState(false);

  useEffect(() => {
    async function loadCars() {
      const cars = await CarsApi.getCars();
      setCars(cars);
    }
    loadCars();
  }, []);

  const handleDeleteClick = async (car: Car) => {
    setLoadingDeleteCar(true);
    await CarsApi.deleteCarById(car.Id);
    setLoadingDeleteCar(false);
  };

  const handleEditCar = async (car: Car) => {
    await CarsApi.addCar(car);
  };

  const columns: ColumnsType<Car> = [
    {
      title: "Id",
      dataIndex: "Id",
      key: "Id",
    },
    {
      title: "Marka",
      dataIndex: "Brand",
      key: "Brand",
    },
    {
      title: "Hp",
      dataIndex: "Hp",
      key: "Hp",
    },
    {
      title: "Akcje",
      key: "action",
      align: "center",
      render: (text: string, record: Car) => (
        <Button
          type="primary"
          danger
          onClick={() => handleDeleteClick(record)}
          loading={loadingDeleteCar}
        >
          Usuń
        </Button>
      ),
    },
  ];

  return (
    <>
      <Button onClick={() => setCarsEditorActive(true)}>Dodaj Auta</Button>
      <CarEditor
        onEdit={handleEditCar}
        visible={carsEditorActive}
        setVisible={setCarsEditorActive}
      />
      <Table columns={columns} dataSource={cars} rowKey="Id" />
    </>
  );
}
