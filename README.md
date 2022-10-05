# Unity

# Managers
 - 어디서든 편하게 사용할 수 있는 매니저
 - 컴포넌트 용도의 C#파일과, 일반적인 C#파일을 구분해서 생각하자
 - 게임 전체를 관리하는 매니저 스크립트!
 -  MonoBehaviour 를 지우면 일반 C#스크립트처럼 사용 할 수있다. 하지만 설계적인 문제가 발생한다.
    
# Singleton Pattern
 - 유일성을 보장한다.
 - 없으면 생성해주고 있으면 생성하지않고 있는 컴포넌트를 사용한다.

 잘 모르는 부분
 & static 과 Singleton, Property 에 대해 알아봐야함
 - Static
   - Static 이란 
   - static 정적이다, static으로 정의를 하면 각 인스턴스에 종속적이지 않고 class에 종속적이 된다.
   - 무슨 차이가 있나? 각기 다른 객체 들에게서 한개의 값만 존재 한다
   - 한 클래스 안에 유일한 필드를 만든다.
   - 함수에도 static 을 붙일 수 있다.
   - static 안에서는 static 만 연산 가능하다.
   - static을 붙이면 클래스에 종속적인 필드, 함수 가 된다. (일반 instnace 에도 생성은 가능하다)
   - static을 안붙이면 인스턴스에 종속적인 필드, 함수 가 된다.
   - static 으로 사용하면 바로 사용 가능하다 (클래스 변수명 = 클래스.static함수/ 기존에는 클래스 변수명 = new 클래스, 변수명.함수명())
   - 

 - Property 
   - Property 란
   - 객체지향 -> 은닉성
   - Getter Get함수, Setter Set함수를 한번에
   - 사용법
     public int HP
     {
         get { return hp;}
         set { hp = value;}
     }