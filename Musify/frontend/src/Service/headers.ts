export const getHeaders = () => {
    return {
        'Authorization': `Bearer ${sessionStorage.getItem('@TOKEN')}`
    }
}