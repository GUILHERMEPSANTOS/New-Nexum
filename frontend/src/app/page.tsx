import Banner from '@/components/banner'
import Footer from '@/components/footer'
import Header from '@/components/header'
import Informations from '@/components/informations'
import SecondBanner from '@/components/secondBanner'

export default function Home() {
  return (
    <>
      <Header />
      <section className="bg-[url('../../public/background-nexus.png')] px-4 h-screen bg-no-repeat bg-cover">
        <Banner />
      </section >
      <div className='px-4 md:px-12'>
        <SecondBanner />
        <Informations />
        <Footer />
      </div>
    </>
  )
}
