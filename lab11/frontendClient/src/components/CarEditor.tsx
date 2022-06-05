import { Form, Input, Modal } from "antd";
import React, { useState } from "react";
import { CarsApi } from "../client/CarsApi";
import { Car } from "../client/types/Car";

type Props = {
  visible: boolean;
  setVisible: (visible: boolean) => void;
  onEdit: (newProduct: Car) => Promise<any>;
};

export function CarEditor({ visible, setVisible, onEdit }: Props) {
  const [form] = Form.useForm();
  const [submitLoading, setSubmitLoading] = useState(false);

  const handleCancel = (): void => {
    form.resetFields();
    setVisible(false);
  };

  const onSubmit = async (values: Car): Promise<void> => {
    setSubmitLoading(true);
    await onEdit({
      Brand: values.Brand,
      Hp: values.Hp,
      Id: values.Id,
    });
    setSubmitLoading(false);
  };

  return (
    <Modal
      title="Edycja produktu"
      visible={visible}
      okText="Zapisz"
      okButtonProps={{ loading: submitLoading }}
      onCancel={handleCancel}
      cancelText="Anuluj"
      onOk={() => {
        form
          .validateFields()
          .then((values) => {
            onSubmit(values);
          })
          .catch(() => null);
      }}
    >
      <Form form={form} name="nest-messages" id="editProductForm">
        <Form.Item
          // initialValue={product.name}
          name={["Brand"]}
          label="Marka"
          rules={[{ required: true, message: "Marka jest wymagana." }]}
        >
          <Input />
        </Form.Item>
        <Form.Item
          // initialValue={product.name}
          name={["Hp"]}
          label="Moc w koniach mechanicznych"
          rules={[{ required: true, message: "Moc jest wymagana." }]}
        >
          <Input type="number" />
        </Form.Item>
        <Form.Item
          // initialValue={product.name}
          name={["Id"]}
          label="Identyfikator "
          rules={[{ required: true, message: "Identyfikator jest wymagany." }]}
        >
          <Input />
        </Form.Item>
      </Form>
    </Modal>
  );
}
