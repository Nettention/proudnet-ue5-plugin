# ProudNet 언리얼 플러그인

이 플러그인은 **Unreal Engine 5에서 ProudNet을 사용하기 위한 종속성 연결 역할**을 합니다.  

---

## 요구 사항
- 이 플러그인은 ProudNet 자체를 포함하지 않습니다.
  ProudNet이 시스템에 **미리 설치**되어 있어야 합니다.  
- Unreal Engine 5.x

---

## 설치 방법

1. 이 저장소의 ProudNet 폴더를 원하는 위치에 복사합니다.  
   - 특정 프로젝트에서만 사용하려면: `<YourProject>/Plugins/`  
   - 엔진 전역에서 사용하려면: `<UnrealEngine>/Engine/Plugins/`

2. ProudNet을 사용하는 모듈의 `.Build.cs` 파일에 종속성을 추가합니다.  
    > 예시 코드
    > ```
    > PublicDependencyModuleNames.AddRange(new string[] { "ProudNet" });
    > ```
---

## 확인 사항

1. 설치 경로 확인  
   - ProudNet이 기본 설치 위치에 있지 않다면, 플러그인 모듈의 `.Build.cs` 에서 참조 경로를 수정해야 합니다.  

2. 플러그인 활성화 확인  
   - 언리얼 에디터의 플러그인 메뉴에서 ProudNet 플러그인이 활성화되어 있는지 확인합니다.  
