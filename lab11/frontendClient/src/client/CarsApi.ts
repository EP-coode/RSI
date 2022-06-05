import { Car } from "./types/Car";

const BASE_URL = "http://localhost:61497/Service1.svc/json";

export class CarsApi {
  static async getCars(): Promise<Car[]> {
    const result = await fetch(`${BASE_URL}/Car`);
    const data = await result.json();
    return data;
  }

  static async getCarById(carId: number): Promise<Car> {
    const result = await fetch(`${BASE_URL}/Car/${carId}`);
    const data = await result.json();
    return data;
  }

  static async addCar(car: Car) {
    const body = await JSON.stringify(car);
    const result = await fetch(`${BASE_URL}/Car`, {
      method: "POST",
      body,
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },
    });
    const data = await result.json();
    return data;
  }

  static async deleteCarById(carId: number): Promise<Car> {
    const result = await fetch(`${BASE_URL}/Car`, {
      method: "DELETE",
    });
    const data = await result.json();
    return data;
  }

  // TODO
  static async getMyDataInfo(): Promise<string> {
    const result = await fetch(`${BASE_URL}/info`);
    const data = await result.json();
    return data;
  }
}
