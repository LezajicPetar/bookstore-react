import AxioConfig from "../config/AxioConfig";

const RESOURCE = "/books";

export const getAllBooks = async () => {
    const response = await AxioConfig.get(RESOURCE);
    return response.data;
}

export const deleteBook = async (id) => {
    await AxioConfig.delete(`${RESOURCE}/${id}`);
}

export const addBook = async () => {

}

export const updateBook = async () => {
    
}