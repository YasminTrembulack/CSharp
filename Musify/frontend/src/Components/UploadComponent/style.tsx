import styled from "styled-components";

export const StyledWrapper = styled.div`
  .custum-file-upload {
  height: 80px;
  width: 256px;
  display: flex;
  flex-direction: row;
  align-items: space-between;
  gap: 20px;
  cursor: pointer;
  align-items: center;
  justify-content: center;
  border: 2px dashed rgba(55, 65, 81, 1);
  background-color: rgba(17, 24, 39, 1);
  padding: 1rem;
  border-radius: 10px;
}

.custum-file-upload .icon {
  display: flex;
  align-items: center;
  justify-content: center;
}

.custum-file-upload .icon svg {
  height: 50px;
  fill: #e8e8e8;
}

.custum-file-upload .text {
  display: flex;
  align-items: center;
  justify-content: center;
}

.custum-file-upload .text span {
  font-weight: 400;
  color: rgba(156, 163, 175, 1);
}

.custum-file-upload input {
  display: none;
}
`;
