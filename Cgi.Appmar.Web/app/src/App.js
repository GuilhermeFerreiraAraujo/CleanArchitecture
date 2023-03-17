import Layout from './Layout'
import './App.scss'
import { useTranslation } from 'react-i18next'

function App() {
  const { t } = useTranslation()

  return (
    <div>
      <h1>{t('helloWorld')}</h1>
      <Layout />
    </div>
  )
}

export default App
