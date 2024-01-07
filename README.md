## Inventory


## 업적 시스템


<p align = "center"><img src="https://jidaeportfolio.s3.ap-northeast-2.amazonaws.com/%EC%9D%B8%EB%B2%A4%ED%86%A0%EB%A6%AC.gif">
</p>

### UML


<p align = "center"><img src="https://jidaeportfolio.s3.ap-northeast-2.amazonaws.com/inventory+UML.PNG.png" height = "500px" weight = "100px">
</p>


### 개발과정
- 게임 기획 단계에서 `아이템들을 유기적으로 교체하며 사용할 수 있으면 좋겠다는 팀원들의 의견을 반영해`  
    `인벤토리를 개발`하게 되었습니다.
- 인벤토리를 제작함에 있어 현재 프로젝트 게임은 플레이어의 무기 종류가 검과 스태프 2가지로 구분되어 있었기에  
  `플레이어가 인벤토리에서 장비를 선택함에 있어 이미지를 제공해 주면 좋을 것 같다는 생각`하여 제작했습니다.  
  그래서 여러가지 `인벤토리 유형 중 UGUI의 Grid Layout group을 사용하여 구현`하게 되었습니다.   
  추가로 각종 `Click, Drag Event 들을 추가하여 유동적으로 장비를 선택하거나 원하는 순서대로 변경할 수 있게 개발`하였습니다.  
- 추후 `아이템 종류의 확장을 대비하여, 인벤토리의 저장될 아이템들 종류의 정보들을 저장하는 ItemDatabase를 Json으로 관리`하였습니다.
    - `이 방식을 사용하기 위해 직렬화와 역직렬화, JsonUtility 등에 대한 공부를 하게 되었습니다.`


### 간단한 클래스 설명


${\textsf{\color\{red}Ctrl + 클릭을 통해 새창열기로 쉽게 코드를 확인하실 수 있습니다.}}$


- [**InvenItem.cs**](https://github.com/shji0318/Inventory/blob/main/InvenItem.cs)
  - 아이템에 대한 정보와 인벤토리 창에서 작용할 Use함수를 포함하고 있는 스크립트
  - 무기에 대한 장착 및 교체 부분 (Use() 부분)
  - player 정보와 image 정보를 초기화해주는 부분 (Init() 부분)
 
  
- [**ItemDatabase.cs**](https://github.com/shji0318/Inventory/blob/main/ItemDatabase.cs)
  - ItemData.json에서 읽어온 아이템 정보를 저장해 놓는 스크립트
 
  
- [**Inventory.cs**](https://github.com/shji0318/Inventory/blob/main/Inventory.cs)
  - 인벤토리에 표현할 아이템 정보를 보관 및 Add,Remove와 같이 추가, 삭제 함수를 포함하고 있는 스크립트
  - 획득 혹은 교체하는 itemValue를 받아 List에 추가한 후, 정보를 업데이트 하는 함수 (AddItem () 부분)
  - 사용 및 삭제할 Slot 번호를 받아 인벤토리에서 없앤 후, 정보를 업데이트 하는 함수 (Remove () 부분)
  - 정보 변경 시 작동할 함수들을 등록하여 사용하기 위해 delegate 사용
    - ex) Slot 정보 Update, 획득 시 종류별로 자동정렬 등
    - 현재 스크립트에서는 RedrawUI를 등록하여 사용

   
- [**Slot.cs**](https://github.com/shji0318/Inventory/blob/main/Slot.cs)
  - 인벤토리 창에 각 슬롯 부분에 해당하는 스크립트
  - 아이템 정보에 따라 아이템 이미지의 Active를 담당하는 함수들 (UpdateSlotUI (), RemoveSlot() 부분)
  - Click, Drag & Drop 이벤트를 담당하는 함수들 (OnPointerUp, OnBeginDrag, OnDrag, OnEndDrag, OnDrop 부분)
  - Drag 이벤트 시, 투명도 변경을 위해 구현한 함수 (ChangeAlpha () 부분)

 
- [**SlotDragEvent.cs**](https://github.com/shji0318/Inventory/blob/main/SlotDragEvent.cs)
  - Drag & Drop 발생 시, Drag를 시작한 Slot의 정보 저장과 Slot간에 정보 변경 작업을 위한 스크립트
    - Drag를 시작하는 오브젝트와 Drop이 되는 곳에 오브젝트가 다르기에 정보를 저장해 놓기 위한 스크립트
  - DragSlot 과 DropSlot에 정보를 통해 정보 변경 작업을 하는 함수 (ChangeSlotItem (Slot) 부분) 


---
