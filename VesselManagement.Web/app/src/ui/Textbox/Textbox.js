import PropTypes from 'prop-types';
import './Textbox.scss'

export default function Textbox(props) {

  function onChange(evt){
    props.onChange(evt.target.value);
  }

  return (<div className='Textbox'>
            <label className='label' for={props.name}>{props.label}</label>
            <input className='input' type={props.type} id={props.id} value={props.value} name={props.name} onChange={(evt) => onChange(evt)}/>
          </div>)
}

Textbox.propTypes = {
  name: PropTypes.string,
  id: PropTypes.number,
  label: PropTypes.string,
  value: PropTypes.string,
  onChange: PropTypes.func
};