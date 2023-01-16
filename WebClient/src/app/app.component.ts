import { OverlayContainer } from '@angular/cdk/overlay';
import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { StateService } from './_services/state.service';
import { MatDrawerMode } from '@angular/material/sidenav';
import { StorageService } from './_services/storage.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'EJH WebClient';
  themes: string[] = ['light', 'dark'];
  selectedTheme: string = 'light';
  themeMap: Map<string, string> = new Map();
  constructor(public s: StateService, private overlayContainer: OverlayContainer, public storageService : StorageService) {
    this.themeMap.set('light', 'light-theme');
    this.themeMap.set('dark', 'dark-theme');
  }

  ngOnInit(): void {
    /*this.themeSelect.valueChanges.subscribe(themeColor => {
      const theme: string | undefined = this.themeMap.get(themeColor);
      this.s.OS.put(this.s.OS.S.theme, theme);
      this.removeThemeClasses();
      this.addThemeClass();
    })*/
    this.selectedTheme = this.storageService.getTheme();
    this.removeThemeClasses();
    this.addThemeClass();
  }

  removeThemeClasses(classPostfix: string = '-theme') {
    const overlayContainerClasses = this.overlayContainer.getContainerElement().classList;
    const themeClassesToRemove = Array.from(overlayContainerClasses).filter((item: string) => item.includes(classPostfix));
    if (themeClassesToRemove.length) {
      overlayContainerClasses.remove(...themeClassesToRemove);
    }
  }

  addThemeClass() {
    const themeClass: string = this.s.OS.snapshot(this.s.OS.S.theme)
    this.overlayContainer.getContainerElement().classList.add(themeClass)
  }
  changeTheme() {
    if (this.selectedTheme == 'light')
      this.selectedTheme = 'dark'
    else
      this.selectedTheme = 'light';
    this.storageService.saveTheme(this.selectedTheme);

    const theme: string | undefined = this.themeMap.get(this.selectedTheme);
    this.s.OS.put(this.s.OS.S.theme, theme);
    this.removeThemeClasses();
    this.addThemeClass();
  }
}
