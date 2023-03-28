import Layout from './Layout'
import { useTranslation } from 'react-i18next'
import Textbox from './ui/Textbox/Textbox'
import CustomButton from './ui/CustomButton/CustomButton'
import { useState } from 'react'
import './App.scss'

import * as UserServices from './services/UserServices'

function App() {
  const { t } = useTranslation()
  const [user, setUser] = useState('')
  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')

  const submit = () =>{

    const data = {
      email, password
    }
    UserServices.Login(data)
    .then((x) => {
      setUser(x)
      console.log('user', x)
    })
    .catch((ex) => {
      console.log(ex)
    })
  }

  return (
    <div className="login">
      {user}
      <Textbox label={t('username')} onChange={(evt) => setEmail(evt)} value={email} />
      <Textbox label={t('password')} type="password" onChange={(evt) => setPassword(evt)} value={password} />

      <CustomButton label={t('login')} onClick={() => submit()}/>
      <Layout />
    </div>
  )
}

export default App
