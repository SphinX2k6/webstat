using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A0B RID: 18955
	[NullableContext(1)]
	[Nullable(0)]
	public class actionMappings
	{
		// Token: 0x060318DF RID: 202975 RVA: 0x00C59EF9 File Offset: 0x00C580F9
		public static bool HasField(string fieldName)
		{
			return typeof(actionMappings).GetField(fieldName) != null;
		}

		// Token: 0x0401CCDA RID: 117978
		public const string 跳跃 = "跳跃";

		// Token: 0x0401CCDB RID: 117979
		public const string 攀爬 = "攀爬";

		// Token: 0x0401CCDC RID: 117980
		public const string 走跑切换 = "走跑切换";

		// Token: 0x0401CCDD RID: 117981
		public const string 攻击 = "攻击";

		// Token: 0x0401CCDE RID: 117982
		public const string 手柄主攻击 = "手柄主攻击";

		// Token: 0x0401CCDF RID: 117983
		public const string 手柄副攻击 = "手柄副攻击";

		// Token: 0x0401CCE0 RID: 117984
		public const string 闪避 = "闪避";

		// Token: 0x0401CCE1 RID: 117985
		public const string 技能1 = "技能1";

		// Token: 0x0401CCE2 RID: 117986
		public const string 幻象1 = "幻象1";

		// Token: 0x0401CCE3 RID: 117987
		public const string 大招 = "大招";

		// Token: 0x0401CCE4 RID: 117988
		public const string 幻象2 = "幻象2";

		// Token: 0x0401CCE5 RID: 117989
		public const string 切换角色1 = "切换角色1";

		// Token: 0x0401CCE6 RID: 117990
		public const string 切换角色2 = "切换角色2";

		// Token: 0x0401CCE7 RID: 117991
		public const string 切换角色3 = "切换角色3";

		// Token: 0x0401CCE8 RID: 117992
		public const string 切换角色4 = "切换角色4";

		// Token: 0x0401CCE9 RID: 117993
		public const string 组合主键 = "组合主键";

		// Token: 0x0401CCEA RID: 117994
		public const string 向前移动 = "向前移动";

		// Token: 0x0401CCEB RID: 117995
		public const string 向后移动 = "向后移动";

		// Token: 0x0401CCEC RID: 117996
		public const string 向左移动 = "向左移动";

		// Token: 0x0401CCED RID: 117997
		public const string 向右移动 = "向右移动";

		// Token: 0x0401CCEE RID: 117998
		public const string 下降 = "下降";

		// Token: 0x0401CCEF RID: 117999
		public const string 邮件 = "邮件";

		// Token: 0x0401CCF0 RID: 118000
		public const string 地图 = "地图";

		// Token: 0x0401CCF1 RID: 118001
		public const string 商店 = "商店";

		// Token: 0x0401CCF2 RID: 118002
		public const string 任务 = "任务";

		// Token: 0x0401CCF3 RID: 118003
		public const string 功能菜单 = "功能菜单";

		// Token: 0x0401CCF4 RID: 118004
		public const string 编队 = "编队";

		// Token: 0x0401CCF5 RID: 118005
		public const string 背包 = "背包";

		// Token: 0x0401CCF6 RID: 118006
		public const string 教程 = "教程";

		// Token: 0x0401CCF7 RID: 118007
		public const string 展开教程百科详情 = "展开教程百科详情";

		// Token: 0x0401CCF8 RID: 118008
		public const string 联机 = "联机";

		// Token: 0x0401CCF9 RID: 118009
		public const string Gm指令 = "GM指令";

		// Token: 0x0401CCFA RID: 118010
		public const string 角色选择界面 = "角色选择界面";

		// Token: 0x0401CCFB RID: 118011
		public const string 幻象列表界面 = "幻象列表界面";

		// Token: 0x0401CCFC RID: 118012
		public const string 聊天 = "聊天";

		// Token: 0x0401CCFD RID: 118013
		public const string 环境特性 = "环境特性";

		// Token: 0x0401CCFE RID: 118014
		public const string 显示鼠标 = "显示鼠标";

		// Token: 0x0401CCFF RID: 118015
		public const string 幻象探索选择界面 = "幻象探索选择界面";

		// Token: 0x0401CD00 RID: 118016
		public const string 轮盘2 = "轮盘2";

		// Token: 0x0401CD01 RID: 118017
		public const string Ui左键点击 = "UI左键点击";

		// Token: 0x0401CD02 RID: 118018
		public const string Ui右键点击 = "UI右键点击";

		// Token: 0x0401CD03 RID: 118019
		public const string 锁定目标 = "锁定目标";

		// Token: 0x0401CD04 RID: 118020
		public const string 瞄准 = "瞄准";

		// Token: 0x0401CD05 RID: 118021
		public const string 通用交互 = "通用交互";

		// Token: 0x0401CD06 RID: 118022
		public const string QTE交互 = "QTE交互";

		// Token: 0x0401CD07 RID: 118023
		public const string 任务追踪 = "任务追踪";

		// Token: 0x0401CD08 RID: 118024
		public const string 切换交互 = "切换交互";

		// Token: 0x0401CD09 RID: 118025
		public const string DebugTap = "DebugTap";

		// Token: 0x0401CD0A RID: 118026
		public const string 拍照 = "拍照";

		// Token: 0x0401CD0B RID: 118027
		public const string 玩法放弃 = "玩法放弃";

		// Token: 0x0401CD0C RID: 118028
		public const string ZoomIn = "ZoomIn";

		// Token: 0x0401CD0D RID: 118029
		public const string ZoomOut = "ZoomOut";

		// Token: 0x0401CD0E RID: 118030
		public const string 轮盘切换 = "轮盘切换";

		// Token: 0x0401CD0F RID: 118031
		public const string 小活动 = "小活动";

		// Token: 0x0401CD10 RID: 118032
		public const string 调谐 = "调谐";

		// Token: 0x0401CD11 RID: 118033
		public const string 变星 = "变星";

		// Token: 0x0401CD12 RID: 118034
		public const string 拾音辑录 = "拾音辑录";

		// Token: 0x0401CD13 RID: 118035
		public const string 放弃改键 = "放弃改键";

		// Token: 0x0401CD14 RID: 118036
		public const string 重新挑战 = "重新挑战";

		// Token: 0x0401CD15 RID: 118037
		public const string UI鼠标中键手柄特右 = "UI鼠标中键手柄特右";

		// Token: 0x0401CD16 RID: 118038
		public const string 退出精简模式 = "退出精简模式";

		// Token: 0x0401CD17 RID: 118039
		public const string 退出精简模式PC触摸板 = "退出精简模式PC触摸板";

		// Token: 0x0401CD18 RID: 118040
		public const string 割草BUFF信息 = "割草BUFF信息";

		// Token: 0x0401CD19 RID: 118041
		public const string 割草BUFF信息PC触摸板 = "割草BUFF信息PC触摸板";

		// Token: 0x0401CD1A RID: 118042
		public const string 滚动条切换 = "滚动条切换";

		// Token: 0x0401CD1B RID: 118043
		public const string Ui返回 = "UI返回";

		// Token: 0x0401CD1C RID: 118044
		public const string Ui方向上 = "UI方向上";

		// Token: 0x0401CD1D RID: 118045
		public const string Ui方向下 = "UI方向下";

		// Token: 0x0401CD1E RID: 118046
		public const string Ui方向左 = "UI方向左";

		// Token: 0x0401CD1F RID: 118047
		public const string Ui方向右 = "UI方向右";

		// Token: 0x0401CD20 RID: 118048
		public const string UI键盘F手柄A = "UI键盘F手柄A";

		// Token: 0x0401CD21 RID: 118049
		public const string UI键盘R手柄X = "UI键盘R手柄X";

		// Token: 0x0401CD22 RID: 118050
		public const string UI键盘T手柄Y = "UI键盘T手柄Y";

		// Token: 0x0401CD23 RID: 118051
		public const string UI键盘Q手柄LB = "UI键盘Q手柄LB";

		// Token: 0x0401CD24 RID: 118052
		public const string UI键盘E手柄RB = "UI键盘E手柄RB";

		// Token: 0x0401CD25 RID: 118053
		public const string UI键盘Z手柄LT = "UI键盘Z手柄LT";

		// Token: 0x0401CD26 RID: 118054
		public const string UI键盘C手柄RT = "UI键盘C手柄RT";

		// Token: 0x0401CD27 RID: 118055
		public const string UI手柄右摇杆上 = "UI手柄右摇杆上";

		// Token: 0x0401CD28 RID: 118056
		public const string UI手柄右摇杆下 = "UI手柄右摇杆下";

		// Token: 0x0401CD29 RID: 118057
		public const string UI键盘G手柄特右 = "UI键盘G手柄特右";

		// Token: 0x0401CD2A RID: 118058
		public const string UI键盘X手柄特左 = "UI键盘X手柄特左";

		// Token: 0x0401CD2B RID: 118059
		public const string UI键盘U手柄左摇杆 = "UI键盘U手柄左摇杆";

		// Token: 0x0401CD2C RID: 118060
		public const string UI键盘G手柄右摇杆 = "UI键盘G手柄右摇杆";

		// Token: 0x0401CD2D RID: 118061
		public const string UI键盘Y手柄特右 = "UI键盘Y手柄特右";

		// Token: 0x0401CD2E RID: 118062
		public const string UI键盘H手柄特左 = "UI键盘H手柄特左";

		// Token: 0x0401CD2F RID: 118063
		public const string UI键盘ESC手柄B = "UI键盘ESC手柄B";

		// Token: 0x0401CD30 RID: 118064
		public const string UI键盘N = "UI键盘N";

		// Token: 0x0401CD31 RID: 118065
		public const string UI键鼠F空格 = "UI键鼠F空格";

		// Token: 0x0401CD32 RID: 118066
		public const string UI手柄A方向右 = "UI手柄A方向右";

		// Token: 0x0401CD33 RID: 118067
		public const string UI手柄B方向左 = "UI手柄B方向左";

		// Token: 0x0401CD34 RID: 118068
		public const string 手柄引导下一步 = "手柄引导下一步";

		// Token: 0x0401CD35 RID: 118069
		public const string UI左摇杆上 = "UI左摇杆上";

		// Token: 0x0401CD36 RID: 118070
		public const string UI左摇杆下 = "UI左摇杆下";

		// Token: 0x0401CD37 RID: 118071
		public const string UI左摇杆左 = "UI左摇杆左";

		// Token: 0x0401CD38 RID: 118072
		public const string UI左摇杆右 = "UI左摇杆右";

		// Token: 0x0401CD39 RID: 118073
		public const string UI鼠标侧键前 = "UI鼠标侧键前";

		// Token: 0x0401CD3A RID: 118074
		public const string UI鼠标侧键后 = "UI鼠标侧键后";

		// Token: 0x0401CD3B RID: 118075
		public const string UI键盘V手柄特左 = "UI键盘V手柄特左";

		// Token: 0x0401CD3C RID: 118076
		public const string UI键盘子弹跳 = "UI键盘子弹跳";

		// Token: 0x0401CD3D RID: 118077
		public const string UI键盘交互 = "UI键盘交互";

		// Token: 0x0401CD3E RID: 118078
		public const string UI手柄退场技 = "UI手柄退场技";

		// Token: 0x0401CD3F RID: 118079
		public const string UI手柄漂移 = "UI手柄漂移";

		// Token: 0x0401CD40 RID: 118080
		public const string 激活聊天 = "激活聊天";

		// Token: 0x0401CD41 RID: 118081
		public const string QTE数字1 = "QTE数字1";

		// Token: 0x0401CD42 RID: 118082
		public const string QTE数字2 = "QTE数字2";

		// Token: 0x0401CD43 RID: 118083
		public const string QTE数字3 = "QTE数字3";

		// Token: 0x0401CD44 RID: 118084
		public const string QTE数字4 = "QTE数字4";

		// Token: 0x0401CD45 RID: 118085
		public const string UI键盘数字1手柄上 = "UI键盘数字1手柄上";

		// Token: 0x0401CD46 RID: 118086
		public const string UI键盘数字2手柄左 = "UI键盘数字2手柄左";

		// Token: 0x0401CD47 RID: 118087
		public const string UI键盘数字3手柄右 = "UI键盘数字3手柄右";

		// Token: 0x0401CD48 RID: 118088
		public const string UI键盘数字4手柄下 = "UI键盘数字4手柄下";

		// Token: 0x0401CD49 RID: 118089
		public const string UI键盘回车 = "UI键盘回车";

		// Token: 0x0401CD4A RID: 118090
		public const string Link大招 = "Link大招";

		// Token: 0x0401CD4B RID: 118091
		public const string 团子养成 = "团子养成";

		// Token: 0x0401CD4C RID: 118092
		public const string 团子商店 = "团子商店";

		// Token: 0x0401CD4D RID: 118093
		public const string 退出团子副本 = "退出团子副本";

		// Token: 0x0401CD4E RID: 118094
		public const string UI键盘空格 = "UI键盘空格";

		// Token: 0x0401CD4F RID: 118095
		public const string 浴场同伴 = "浴场同伴";

		// Token: 0x0401CD50 RID: 118096
		public const string 浴场切换视角 = "浴场切换视角";

		// Token: 0x0401CD51 RID: 118097
		public const string 浴场快照 = "浴场快照";

		// Token: 0x0401CD52 RID: 118098
		public const string 组合菜单键 = "组合菜单键";

		// Token: 0x0401CD53 RID: 118099
		public const string 塔防射击 = "塔防射击";

		// Token: 0x0401CD54 RID: 118100
		public const string 塔防旋转 = "塔防旋转";

		// Token: 0x0401CD55 RID: 118101
		public const string 塔防回收机关 = "塔防回收机关";

		// Token: 0x0401CD56 RID: 118102
		public const string 塔防整备 = "塔防整备";

		// Token: 0x0401CD57 RID: 118103
		public const string 塔防开始 = "塔防开始";

		// Token: 0x0401CD58 RID: 118104
		public const string 塔防选择1 = "塔防选择1";

		// Token: 0x0401CD59 RID: 118105
		public const string 塔防选择2 = "塔防选择2";

		// Token: 0x0401CD5A RID: 118106
		public const string 塔防选择3 = "塔防选择3";

		// Token: 0x0401CD5B RID: 118107
		public const string 塔防选择4 = "塔防选择4";

		// Token: 0x0401CD5C RID: 118108
		public const string 塔防选择5 = "塔防选择5";

		// Token: 0x0401CD5D RID: 118109
		public const string 塔防选择6 = "塔防选择6";

		// Token: 0x0401CD5E RID: 118110
		public const string 塔防选择7 = "塔防选择7";

		// Token: 0x0401CD5F RID: 118111
		public const string 塔防选择8 = "塔防选择8";

		// Token: 0x0401CD60 RID: 118112
		public const string 塔防跳跃 = "塔防跳跃";

		// Token: 0x0401CD61 RID: 118113
		public const string 塔防冲刺 = "塔防冲刺";

		// Token: 0x0401CD62 RID: 118114
		public const string 塔防选择上一个 = "塔防选择上一个";

		// Token: 0x0401CD63 RID: 118115
		public const string 塔防选择下一个 = "塔防选择下一个";

		// Token: 0x0401CD64 RID: 118116
		public const string 塔防组合主键 = "塔防组合主键";

		// Token: 0x0401CD65 RID: 118117
		public const string 塔防商店 = "塔防商店";

		// Token: 0x0401CD66 RID: 118118
		public const string 塔防轮盘 = "塔防轮盘";

		// Token: 0x0401CD67 RID: 118119
		public const string 塔防道具 = "塔防道具";

		// Token: 0x0401CD68 RID: 118120
		public const string 塔防地图 = "塔防地图";

		// Token: 0x0401CD69 RID: 118121
		public const string 塔防走跑切换 = "塔防走跑切换";

		// Token: 0x0401CD6A RID: 118122
		public const string 交互动态漫_向上拖动 = "交互动态漫-向上拖动";

		// Token: 0x0401CD6B RID: 118123
		public const string 交互动态漫_向下拖动 = "交互动态漫-向下拖动";

		// Token: 0x0401CD6C RID: 118124
		public const string 交互动态漫_转动 = "交互动态漫-转动";

		// Token: 0x0401CD6D RID: 118125
		public const string 交互动态漫_点击 = "交互动态漫-点击";

		// Token: 0x0401CD6E RID: 118126
		public const string 交互动态漫_长按 = "交互动态漫-长按";

		// Token: 0x0401CD6F RID: 118127
		public const string QTE选项1 = "QTE选项1";

		// Token: 0x0401CD70 RID: 118128
		public const string QTE选项2 = "QTE选项2";

		// Token: 0x0401CD71 RID: 118129
		public const string QTE选项3 = "QTE选项3";

		// Token: 0x0401CD72 RID: 118130
		public const string QTE选项4 = "QTE选项4";

		// Token: 0x0401CD73 RID: 118131
		public const string QTE方向上 = "qte方向上";

		// Token: 0x0401CD74 RID: 118132
		public const string QTE方向下 = "qte方向下";

		// Token: 0x0401CD75 RID: 118133
		public const string QTE方向左 = "qte方向左";

		// Token: 0x0401CD76 RID: 118134
		public const string QTE方向右 = "qte方向右";

		// Token: 0x0401CD77 RID: 118135
		public const string QTE分体选项1_左 = "QTE分体选项1-左";

		// Token: 0x0401CD78 RID: 118136
		public const string QTE分体选项2_右 = "QTE分体选项2-右";

		// Token: 0x0401CD79 RID: 118137
		public const string QTE_R2攻击 = "QTE-R2攻击";

		// Token: 0x0401CD7A RID: 118138
		public const string QTE_空格A = "QTE-空格和A键";

		// Token: 0x0401CD7B RID: 118139
		public const string D级限时选项_1 = "D级限时选项-1";

		// Token: 0x0401CD7C RID: 118140
		public const string D级限时选项_2 = "D级限时选项-2";

		// Token: 0x0401CD7D RID: 118141
		public const string 载具漂移 = "载具漂移";

		// Token: 0x0401CD7E RID: 118142
		public const string 载具子弹跳 = "载具子弹跳";

		// Token: 0x0401CD7F RID: 118143
		public const string 载具子弹跳1 = "载具子弹跳1";

		// Token: 0x0401CD80 RID: 118144
		public const string 载具退场技和下车 = "载具退场技和下车";

		// Token: 0x0401CD81 RID: 118145
		public const string 载具探索工具 = "载具探索工具";

		// Token: 0x0401CD82 RID: 118146
		public const string 载具氮气 = "载具氮气";

		// Token: 0x0401CD83 RID: 118147
		public const string 载具视角切换 = "载具视角切换";

		// Token: 0x0401CD84 RID: 118148
		public const string 载具空中抬升 = "载具空中抬升";

		// Token: 0x0401CD85 RID: 118149
		public const string 载具音乐上一首 = "载具音乐上一首";

		// Token: 0x0401CD86 RID: 118150
		public const string 载具音乐下一首 = "载具音乐下一首";

		// Token: 0x0401CD87 RID: 118151
		public const string 载具音乐播放暂停 = "载具音乐播放暂停";

		// Token: 0x0401CD88 RID: 118152
		public const string 载具锁定目标 = "载具锁定目标";

		// Token: 0x0401CD89 RID: 118153
		public const string 载具辅助机攻击 = "载具辅助机攻击";

		// Token: 0x0401CD8A RID: 118154
		public const string 飞讯 = "飞讯";

		// Token: 0x0401CD8B RID: 118155
		public const string 弹珠挡板 = "弹珠挡板";

		// Token: 0x0401CD8C RID: 118156
		public const string 弹珠冲刺 = "弹珠冲刺";

		// Token: 0x0401CD8D RID: 118157
		public const string 全量点击继续 = "全量点击继续";
	}
}
