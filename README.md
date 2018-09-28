# VICER_ANDROID
 
## 소개
클라이언트가 자신의 컨트롤러와 차량을 연결하고 360영상을 Gear VR로 수신하기 위한 Application이다.

#### Application 기능
* Database와 비교하여 사용자별 메뉴화면으로 로그인
* 제작된 컨트롤러로 부터 받은 제어값을 Bluetooth 통신으로 받아 소켓서버에 전송
* 차량 제어 준비가 끝나면 Gear VR에 장착하여 차량으로부터 수신된 360도 스트리밍 영상을 송출

## 개발환경 설정.
VR 화면을 어플에서 제공해주기 위하여 XR 시장의 2/3을 차지하고 있는 Unity를 사용하여 개발하였다.</br>
Samsung Gear VR을 사용하기 위하여 핸드폰 기종은 Galaxy 시리즈를 사용한다.

### 유니티
* 유니티는 무료배포 버전과 Pro 버전이 있다. 본 제품에서는 기본으로 제공되는 Personal 버전을 사용하였다. 
* 최신버전의 유니티 에디터의 경우 안드로이드 sdk를 통해 모바일로 빌드하는 과정에서 호환이 되지 않는 경우가 많으므로 한 단계 아래버전인 2017 버전을 사용하였다.  
   * https://unity3d.com/kr/get-unity/download/archive?_ga=2.139035312.2061731462.1538114974-889079946.1538114974
   * 위의 링크에서 유니티 2017.4.3 버전을 설치받는다.
   
### 안드로이드 sdk
* 유니티에서 apk파일로 빌드하기 위하여 유니티 preference에 등록 해주어야 합니다.
* https://developer.android.com/studio/ 링크에서 Android studio를 설치합니다.
* 스튜디오를 실행시킨 후 SDK manager를 통해 유니티의 XR기능을 사용하기 위한 최소 API 레벨인 19이상의 플랫폼과 tool을 다운받습니다.
* 유니티의 Edit - Preferences 에 들어가 ExternalTools에서 다운로드받은 sdk의 경로를 설정 해줍니다.

### JDK
* 모바일로 빌드하기 위해 필요한 Java Development kit를 유니티에서 설정해 주어야 합니다.
* https://www.oracle.com/technetwork/java/javase/downloads/jdk8-downloads-2133151.html
* Java SE Development Kit 8u181 에서 OS에 맞는 버전을 받아 sdk와 마찬가지로 External Tools의 jdk칸에 경로를 설정 해줍니다.

## 설치
깃에 첨부된 unity 프로젝트를 다운 받아 유니티로 열어준다.
<img src="./Img/BuildSettings.jpg"> 
* 사용할 핸드폰에 컴퓨터를 연결 시켜주고 Build & run 시켜준다.


## 메뉴 구성도
<img src="./Img/메뉴 흐름도.jpg">

```
test?
```



## 라이센스
* jdk : You must accept the Oracle Binary Code License Agreement for Java SE to download this software.
