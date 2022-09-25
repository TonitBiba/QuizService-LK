import React from "react";
import sq from "./Messages/sq.json";
import en from "./Messages/en.json";
import no from "./Messages/no.json";
import { IntlProvider } from "react-intl";
import { useSelector, shallowEqual } from "react-redux";
import { RootState } from "../../Redux/Reducers/RootReducer";

const I18N_Config_key = "i18nConfig";

const typeOfMessages = {
  sq: sq,
  en: en,
  no: no
};

type Props = {
  selectedLang: "sq" | "en" | "no";
};

const initialLang: Props = {
  selectedLang: "en"
};

const I18nContext = React.createContext<Props>(initialLang);

function getConfig(): Props {
  const ls = localStorage.getItem(I18N_Config_key);
  if (ls) {
    try {
      return JSON.parse(ls) as Props;
    } catch (er) {
      console.log(er);
    }
  }
  return initialLang;
}

export function LangThemeProvider({ children }: { children: React.ReactNode }) {
  const lang = getConfig();
  return <I18nContext.Provider value={lang}>{children}</I18nContext.Provider>;
}

export default function I18nProvider({ children }: { children: React.ReactNode }) {
  const lang = useSelector<RootState>(({ theme }) => theme.lang, shallowEqual) as "sq" | "en" | "no";
  return (
    <IntlProvider locale={lang} messages={typeOfMessages[lang]}>
      {children}
    </IntlProvider>
  );
}
