interface TsButtonProps {
  text: string;
  onClick: () => void;
}

export const TsButton = ({ text, onClick }: TsButtonProps) => {
  return <button className="btn" onClick={onClick}>{text}</button>;
};