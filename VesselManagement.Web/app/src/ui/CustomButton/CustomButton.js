import * as React from 'react'
import PropTypes from 'prop-types';

import Button from '@mui/material/Button'

export default function CustomButton(props) {
  return (
    <div>
      <Button variant="contained" onClick={() => props.onClick()}>{props.label}</Button>
    </div>
  )
}

CustomButton.propTypes = {
  label: PropTypes.string,
  onClick: PropTypes.func
};