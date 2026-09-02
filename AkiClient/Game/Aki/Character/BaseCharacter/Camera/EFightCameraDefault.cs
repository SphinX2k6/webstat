using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x020042F7 RID: 17143
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/EFightCameraDefault.EFightCameraDefault")]
	public enum EFightCameraDefault : byte
	{
		// Token: 0x04019880 RID: 104576
		None,
		// Token: 0x04019881 RID: 104577
		基础臂长,
		// Token: 0x04019882 RID: 104578
		最小臂长,
		// Token: 0x04019883 RID: 104579
		最大臂长,
		// Token: 0x04019884 RID: 104580
		废弃1,
		// Token: 0x04019885 RID: 104581
		Fov,
		// Token: 0x04019886 RID: 104582
		相机臂偏移X,
		// Token: 0x04019887 RID: 104583
		相机臂偏移Y,
		// Token: 0x04019888 RID: 104584
		相机臂偏移Z,
		// Token: 0x04019889 RID: 104585
		切换角色相机臂中心点过渡时间,
		// Token: 0x0401988A RID: 104586
		在水中摄像机碰撞检测起点额外高度,
		// Token: 0x0401988B RID: 104587
		障碍碰撞检测胶囊体半径,
		// Token: 0x0401988C RID: 104588
		自动俯仰角输入水平偏移,
		// Token: 0x0401988D RID: 104589
		自动俯仰角输入垂直偏移,
		// Token: 0x0401988E RID: 104590
		自动俯仰角输入下界,
		// Token: 0x0401988F RID: 104591
		自动俯仰角输入中界,
		// Token: 0x04019890 RID: 104592
		自动俯仰角输入上界,
		// Token: 0x04019891 RID: 104593
		自动俯仰角输出下界,
		// Token: 0x04019892 RID: 104594
		自动俯仰角输出中界,
		// Token: 0x04019893 RID: 104595
		自动俯仰角输出上界,
		// Token: 0x04019894 RID: 104596
		弹簧臂中心点上下插值最小速度,
		// Token: 0x04019895 RID: 104597
		弹簧臂中心点上下插值最大速度,
		// Token: 0x04019896 RID: 104598
		弹簧臂中心点上下偏移距离下界,
		// Token: 0x04019897 RID: 104599
		弹簧臂中心点上下偏移距离上界,
		// Token: 0x04019898 RID: 104600
		最小上浮臂长,
		// Token: 0x04019899 RID: 104601
		最大上浮臂长,
		// Token: 0x0401989A RID: 104602
		弹簧臂中心点前后插值最小速度,
		// Token: 0x0401989B RID: 104603
		弹簧臂中心点前后插值最大速度,
		// Token: 0x0401989C RID: 104604
		弹簧臂中心点前后偏移距离下界,
		// Token: 0x0401989D RID: 104605
		弹簧臂中心点前后偏移距离上界,
		// Token: 0x0401989E RID: 104606
		复查障碍碰撞检测胶囊体半径,
		// Token: 0x0401989F RID: 104607
		复查障碍碰撞检测间隔距离,
		// Token: 0x040198A0 RID: 104608
		退出障碍碰撞检测胶囊体半径,
		// Token: 0x040198A1 RID: 104609
		Yaw限制Min,
		// Token: 0x040198A2 RID: 104610
		Yaw限制Max,
		// Token: 0x040198A3 RID: 104611
		MaxDistance,
		// Token: 0x040198A4 RID: 104612
		InSpeed,
		// Token: 0x040198A5 RID: 104613
		OutSpeed,
		// Token: 0x040198A6 RID: 104614
		CollisionSizePercentage,
		// Token: 0x040198A7 RID: 104615
		CenterCollisionSize,
		// Token: 0x040198A8 RID: 104616
		角色开始虚化距离,
		// Token: 0x040198A9 RID: 104617
		角色最大虚化距离,
		// Token: 0x040198AA RID: 104618
		角色开始虚化仰视角,
		// Token: 0x040198AB RID: 104619
		角色最大虚化仰视角,
		// Token: 0x040198AC RID: 104620
		角色虚化不透明度,
		// Token: 0x040198AD RID: 104621
		Pitch限制Min,
		// Token: 0x040198AE RID: 104622
		Pitch限制Max,
		// Token: 0x040198AF RID: 104623
		弹簧臂中心点左右插值最小速度,
		// Token: 0x040198B0 RID: 104624
		弹簧臂中心点左右插值最大速度,
		// Token: 0x040198B1 RID: 104625
		弹簧臂中心点左右偏移距离下界,
		// Token: 0x040198B2 RID: 104626
		弹簧臂中心点左右偏移距离上界,
		// Token: 0x040198B3 RID: 104627
		瞄准射击俯视Z轴偏移,
		// Token: 0x040198B4 RID: 104628
		瞄准射击仰视Z轴偏移,
		// Token: 0x040198B5 RID: 104629
		游标目标旋转Alpha速率下界,
		// Token: 0x040198B6 RID: 104630
		游标目标旋转Alpha速率上界,
		// Token: 0x040198B7 RID: 104631
		游标目标旋转Alpha速率,
		// Token: 0x040198B8 RID: 104632
		禁用重置视角,
		// Token: 0x040198B9 RID: 104633
		额外Pitch最小叠加值,
		// Token: 0x040198BA RID: 104634
		额外Pitch最大叠加值,
		// Token: 0x040198BB RID: 104635
		额外Pitch叠加高度,
		// Token: 0x040198BC RID: 104636
		WorldYaw限制Min,
		// Token: 0x040198BD RID: 104637
		WorldYaw限制Max,
		// Token: 0x040198BE RID: 104638
		相机臂原点偏移X,
		// Token: 0x040198BF RID: 104639
		相机臂原点偏移Y,
		// Token: 0x040198C0 RID: 104640
		相机臂原点偏移Z,
		// Token: 0x040198C1 RID: 104641
		相机臂原点最小地面偏移Z,
		// Token: 0x040198C2 RID: 104642
		Yaw软区Min,
		// Token: 0x040198C3 RID: 104643
		Yaw软区Max,
		// Token: 0x040198C4 RID: 104644
		Yaw死区Min,
		// Token: 0x040198C5 RID: 104645
		Yaw死区Max,
		// Token: 0x040198C6 RID: 104646
		软区模式,
		// Token: 0x040198C7 RID: 104647
		Yaw区间最小速度,
		// Token: 0x040198C8 RID: 104648
		Yaw区间最大速度,
		// Token: 0x040198C9 RID: 104649
		Yaw死区到软区过渡速度倍率,
		// Token: 0x040198CA RID: 104650
		Yaw回正速度倍率,
		// Token: 0x040198CB RID: 104651
		弹簧臂中心点左右回正速度,
		// Token: 0x040198CC RID: 104652
		弹簧臂中心点左右转向角度曲线参数范围,
		// Token: 0x040198CD RID: 104653
		Yaw输入启用时间,
		// Token: 0x040198CE RID: 104654
		Yaw回正时间,
		// Token: 0x040198CF RID: 104655
		Pitch输入启动时间,
		// Token: 0x040198D0 RID: 104656
		Pitch回正时间,
		// Token: 0x040198D1 RID: 104657
		Pitch软区Min,
		// Token: 0x040198D2 RID: 104658
		Pitch软区Max,
		// Token: 0x040198D3 RID: 104659
		Pitch死区Min,
		// Token: 0x040198D4 RID: 104660
		Pitch死区Max,
		// Token: 0x040198D5 RID: 104661
		Pitch区域基准值,
		// Token: 0x040198D6 RID: 104662
		Pitch区间最小速度,
		// Token: 0x040198D7 RID: 104663
		Pitch区间最大速度,
		// Token: 0x040198D8 RID: 104664
		相机臂Z随臂长变化自动偏移_最小臂长_,
		// Token: 0x040198D9 RID: 104665
		相机臂Z随臂长变化自动偏移_最大臂长_,
		// Token: 0x040198DA RID: 104666
		相机臂Z随臂长变化自动偏移_最小Z偏移_,
		// Token: 0x040198DB RID: 104667
		相机臂Z随臂长变化自动偏移_最大Z偏移_,
		// Token: 0x040198DC RID: 104668
		角色叠加臂长,
		// Token: 0x040198DD RID: 104669
		角色叠加偏移Z,
		// Token: 0x040198DE RID: 104670
		战斗拍照角色开始虚化仰视角,
		// Token: 0x040198DF RID: 104671
		战斗拍照角色最大虚化仰视角,
		// Token: 0x040198E0 RID: 104672
		战斗拍照角色开始虚化距离,
		// Token: 0x040198E1 RID: 104673
		战斗拍照角色最大虚化距离,
		// Token: 0x040198E2 RID: 104674
		战斗拍照角色虚化不透明度,
		// Token: 0x040198E3 RID: 104675
		拍照界面npc开始虚化距离,
		// Token: 0x040198E4 RID: 104676
		拍照界面npc最大虚化距离,
		// Token: 0x040198E5 RID: 104677
		拍照界面npc虚化不透明度,
		// Token: 0x040198E6 RID: 104678
		开启动态FOV,
		// Token: 0x040198E7 RID: 104679
		动态FOV下界,
		// Token: 0x040198E8 RID: 104680
		动态FOV上界,
		// Token: 0x040198E9 RID: 104681
		动态FOV映射下界,
		// Token: 0x040198EA RID: 104682
		动态FOV映射上界,
		// Token: 0x040198EB RID: 104683
		动态FOV插值速度,
		// Token: 0x040198EC RID: 104684
		Yaw软区过渡速度倍率,
		// Token: 0x040198ED RID: 104685
		弹簧臂中心点上下输入启用时间,
		// Token: 0x040198EE RID: 104686
		弹簧臂中心点上下回正启用时间,
		// Token: 0x040198EF RID: 104687
		弹簧臂中心点左右输入启用时间,
		// Token: 0x040198F0 RID: 104688
		弹簧臂中心点左右回正启用时间,
		// Token: 0x040198F1 RID: 104689
		弹簧臂中心点前后输入启用时间,
		// Token: 0x040198F2 RID: 104690
		弹簧臂中心点前后回正启用时间,
		// Token: 0x040198F3 RID: 104691
		弹簧臂左右固定,
		// Token: 0x040198F4 RID: 104692
		弹簧臂上下固定,
		// Token: 0x040198F5 RID: 104693
		弹簧臂前后固定,
		// Token: 0x040198F6 RID: 104694
		WorldRoll限制Min,
		// Token: 0x040198F7 RID: 104695
		WorldRoll限制Max,
		// Token: 0x040198F8 RID: 104696
		EFightCameraDefault_MAX
	}
}
