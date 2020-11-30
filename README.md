# ToyProject
## 1. WPF Window 내에서 Window스타일 Modal 모의 Element 구현

+ ### 기간
	+ 20/11/18 ~ 20/11/23

+ ### 목적
	+ 훈련장비 모의시 훈련장비에 부착된 패널 내·외부 인터페이스에서 사용되는 요소들(버튼, 모달 등등)을 현실장	비와 비슷하게 구현하기 위해 연습하기위함.

+ ### 구현기능
	+ 패널 버튼(모달창 여부와 관계없이 작동)
	+ 패널 내 화면에 출력되는 버튼, 모달 등 인터페이스
	+ 모달창 최소화, 최대화 기능
	+ 모달창 최대화후 최소화시 이전위치 이동
	+ 모달창 최대화후 최소화시 이전크기로 변경
	+ 모달창 생성시 뒷 배경 Control 클릭이벤트 차단

+ ### 참조 URL
	+ WPF Canvas에서의 Element Drag기능 구현
	https://stackoverflow.com/questions/1495408/how-to-drag-a-usercontrol-inside-a-canvas

	+ WPF ClickEvent Bubbling 차단
	https://dotnetmvp.tistory.com/32

	+ 같은 컨셉으로 구현되있는 라이브러리 설명
	https://stackoverflow.com/questions/30407331/c-sharp-wpf-child-windows-inside-main-window

+ ### 구동 화면

| 실행화면 			| 모달 생성시 			|
| ------------ 			| ------------ 			|
| ![image.png](/yobi/files/229) | ![image.png](/yobi/files/230) |

| 모달최대화 			| 화면 끔 버튼 클릭시		|
| ------------ 			| ------------ 			|
| ![image.png](/yobi/files/231) | ![image.png](/yobi/files/232) |

+ ### 소스코드
	+ Git – https://github.com/ssm8887/WPF-ToyProject-1.WindowModal
	+ Yobi - http://ms-filesvr:9000/yobi/ssm8887/ToyProject-1.WindowModal
