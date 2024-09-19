export default function UploadMusic(){

    return (
        

                <InputContainer>
                    <h1>Upload de Música</h1>
                    <form id="uploadForm" encType="multipart/form-data" method="post" action="http://localhost:5036/upload-music">
                        <label htmlFor="fileInput">Escolha um arquivo de música:</label>
                        <input type="file" id="fileInput" name="payloadFiles" accept="audio/*" multiple required/>
                        <br/><br/>
                        <button type="submit">Enviar</button>
                    </form>
                </InputContainer>
        

        
    )
}
