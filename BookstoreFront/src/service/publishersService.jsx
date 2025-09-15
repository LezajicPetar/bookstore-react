import axios from "../config/AxioConfig.js";

const RESOURCE = "/publishers";

export const getAllPublishers = async () => {
    const response = await axios.get(RESOURCE);
    return response.data;
}