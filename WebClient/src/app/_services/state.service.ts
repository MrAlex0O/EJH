
import { Injectable } from "@angular/core";
import { KeyObsValueReset, ObsValueReset, OStore, OStoreStart } from '@fireflysemantics/slice'
import { Observable } from "rxjs";
import { StorageService } from "./storage.service";



interface ISTART extends KeyObsValueReset {
  theme: ObsValueReset
}

@Injectable({
  providedIn: "root"
})
export class StateService {
  constructor(public storage: StorageService) { }

  START: OStoreStart = {
    theme: { value: this.storage.getTheme() +'-theme' }
  }
  public OS: OStore<ISTART> = new OStore(this.START)
  public selectedTheme$: Observable<string> = this.OS.S.theme.obs
}
