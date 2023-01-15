import { OverlayContainer } from '@angular/cdk/overlay';
import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { StateService } from './_services/state.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'EJH WebClient';
  themes: string[] = ['light', 'dark'];
  themeMap: Map<string, string> = new Map();
  public themeSelect = new FormControl(
    this.s.OS.snapshot(this.s.OS.S.theme));

  constructor(public s: StateService, private overlayContainer: OverlayContainer) {
    this.themeMap.set('light', 'light-theme');
    this.themeMap.set('dark', 'dark-theme');
  }

  ngOnInit(): void {
    this.themeSelect.valueChanges.subscribe(themeColor => {
      const theme: string | undefined = this.themeMap.get(themeColor);
      this.s.OS.put(this.s.OS.S.theme, theme);
      this.removeThemeClasses();
      this.addThemeClass();
    })
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

}
