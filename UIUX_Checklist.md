# UI/UX 자체 체크리스트

## UI 구현
- [ ] UGUI와 TextMeshPro를 사용했다.
- [ ] Canvas Scaler 기준 해상도를 1920×1080으로 설정했다.
- [ ] HUD에 Players와 Time 정보가 표시된다.
- [ ] 게임 상태에 따라 Players와 Time 값이 변경된다.

## 메뉴 및 화면 전환
- [ ] 타이틀 화면이 표시된다.
- [ ] 플레이 HUD가 표시된다.
- [ ] ESC로 Pause 메뉴를 열 수 있다.
- [ ] Resume 버튼으로 게임을 계속할 수 있다.
- [ ] Title 버튼으로 타이틀 화면으로 이동할 수 있다.
- [ ] 게임 종료 시 Result 화면이 표시된다.
- [ ] Result 화면에서 GAME START!가 겹쳐 표시되지 않는다.

## 입력
- [ ] 마우스로 UI 버튼을 조작할 수 있다.
- [ ] 방향키로 메뉴 선택을 이동할 수 있다.
- [ ] Enter로 선택한 버튼을 실행할 수 있다.
- [ ] ESC로 Pause 메뉴를 열 수 있다.

## UI/UX 피드백
- [ ] 선택된 버튼의 색상 변화가 확인된다.
- [ ] PLAYER FOUND! 알림이 표시된다.

## 재사용 UI
- [ ] ResumeButton Prefab을 만들었다.
- [ ] ToastText Prefab을 만들었다.

## 테스트
- [ ] 해상도 변경 테스트를 했다.
- [ ] 화면 전환을 테스트했다.
- [ ] UI 입력을 테스트했다.
- [ ] 플레이어 수와 타이머 데이터 연결을 확인했다.
- [ ] Console에 오류가 없는 것을 확인했다.

## 테스트 결과 기록

### 테스트 1 — Pause 메뉴 버튼 선택

- 기대 결과: 방향키로 Resume과 Title 버튼 사이를 이동할 수 있어야 한다.
- 실제 결과: 아래 방향키는 정상적으로 이동했지만 위 방향키가 동작하지 않았다.
- 수정 내용: ResumeButton과 PauseTitleButton의 Button Navigation을 Explicit으로 설정하고 Select On Up / Select On Down을 연결했다.
- 다시 확인한 결과: 방향키 위·아래 이동과 선택 색상 변화가 정상적으로 동작했다.

### 테스트 2 — 게임 종료 결과 화면

- 기대 결과: 게임 종료 시 GAME CLEAR와 TITLE 버튼이 표시되고 GAME START가 겹쳐 보이지 않아야 한다.
- 실제 결과: GAME START가 결과 화면에 남아 GAME CLEAR와 겹쳐 표시되었다.
- 수정 내용: GameHUD에 GameTitle을 연결하고 ShowResult()에서 GameTitle을 비활성화하도록 수정했다.
- 다시 확인한 결과: 게임 종료 시 GAME START가 사라지고 GAME CLEAR와 TITLE 버튼만 정상적으로 표시되었다.

## GUI 디자인 가이드

| 항목 | 기준 |
|---|---|
| 기준 해상도 | 1920 × 1080 |
| UI 배율 | Canvas Scaler - Scale With Screen Size |
| 버튼 조작 | 마우스 클릭 / 방향키 / Enter |
| 뒤로 가기 | ESC |
| 정보 우선순위 | 플레이어 수와 남은 시간을 우선 표시 |
| 버튼 피드백 | 선택 시 색상 변화 |
| 알림 피드백 | PLAYER FOUND! 메시지 표시 |
| 텍스트 | TextMeshProUGUI 사용 |
| 버튼 크기 | 마우스와 키보드 모두 쉽게 선택할 수 있도록 충분한 크기 유지 |
| 글자 대비 | 배경과 구분되는 색상 사용 |

## 구현 가능성 검토

초기 UI 구성에서는 게임 플레이에 필요한 정보를 우선적으로 표시하도록 설계했다. 
숨바꼭질 게임의 특성상 체력 시스템은 필요하지 않다고 판단하여 제외하고, 
플레이어 수와 남은 시간을 HUD의 주요 정보로 구성했다.

UI 입력은 마우스뿐만 아니라 방향키와 Enter, ESC를 사용할 수 있도록 Input System과 EventSystem을 구성했다.

실제 테스트 과정에서 Pause 메뉴의 위 방향키 이동이 동작하지 않는 문제가 발견되었으며, 
Button Navigation을 Explicit으로 설정하고 각 버튼의 이동 대상을 연결하여 수정했다.

또한 결과 화면에서 기존 GAME START 텍스트가 GAME CLEAR 화면과 겹치는 문제가 발생하여 
게임 종료 시 GameTitle을 비활성화하도록 수정했다.