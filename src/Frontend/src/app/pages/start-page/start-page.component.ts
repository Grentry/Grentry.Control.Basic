import { Component, OnInit } from '@angular/core';
import { timer } from 'rxjs';
import { TextItem, WebsiteClient } from 'src/app/apis/website-client';

@Component({
  selector: 'app-start-page',
  templateUrl: './start-page.component.html',
  styleUrls: ['./start-page.component.scss']
})
export class StartPageComponent implements OnInit {

  backgroundColorStyle = { 'background-color': "#c0c0c0"}
  textItems: Item[] = []
  constructor(private websiteClient: WebsiteClient) { }

  async ngOnInit(): Promise<void> {
    timer(0, 200).subscribe(async () => {  await this.requestWebsiteState(); });
  }

  async requestWebsiteState()
  {
    var data = await this.websiteClient.website().toPromise();
    this.textItems = [];

    this.setBackgroundColorStyle(data.backgroundColor ?? '#c0c0c0');
    for(let item of data.textItems ?? [])
    {
      this.textItems.push(this.getItem(item));
    }

  }

  getItem(textItem: TextItem)
  {
    const item = new Item();
    item.height = textItem.height;
    item.text = textItem.text;
    item.textSize = textItem.textSize;
    item.width = textItem.width;
    item.xPosition = textItem.xPosition;
    item.yPosition = textItem.yPosition;
    item.style = this.getItemStyle(textItem);
    
    return item;
  }

  getItemStyle(textItem: TextItem) : any
  {
    let style = {
      'width': textItem.width + 'px',
      'height': textItem.height + 'px',
      'font-size': textItem.textSize + 'px',
      'left': textItem.xPosition + 'px',
      'bottom': textItem.yPosition + 'px',
      'position': 'absolute',
      'text-align': 'center'
    }

    return style;
  }

  setBackgroundColorStyle(color: string)
  {
    this.backgroundColorStyle = { 'background-color': color}
  }

}

class Item extends TextItem
{
  style: any;
}
