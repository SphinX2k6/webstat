using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using CSharpScript.Launcher.Util;
using UnrealEngine;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x02004570 RID: 17776
	[NullableContext(1)]
	[Nullable(0)]
	public class PlatformSdkReportBaseData : IStaticVariableResetter
	{
		// Token: 0x0602EBEB RID: 191467 RVA: 0x00B12158 File Offset: 0x00B10358
		static PlatformSdkReportBaseData()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(PlatformSdkReportBaseData.CreateStaticDefaultValue), new Action(PlatformSdkReportBaseData.ResetStaticDefaultValue));
		}

		// Token: 0x0602EBEC RID: 191468 RVA: 0x00B1223D File Offset: 0x00B1043D
		public static void CreateStaticDefaultValue()
		{
		}

		// Token: 0x0602EBED RID: 191469 RVA: 0x00B12240 File Offset: 0x00B10440
		public static void ResetStaticDefaultValue()
		{
			PlatformSdkReportBaseData.BasePkgId = "";
			PlatformSdkReportBaseData.BasePkgName = "";
			PlatformSdkReportBaseData.BaseChannelId = "";
			PlatformSdkReportBaseData.BaseChannelName = "";
			PlatformSdkReportBaseData.BaseChannelOp = "";
			PlatformSdkReportBaseData.BaseLanguage = "";
			PlatformSdkReportBaseData.BaseRoleName = "";
			PlatformSdkReportBaseData.BaseServerName = "";
			PlatformSdkReportBaseData.BaseServerId = "";
			PlatformSdkReportBaseData.BaseRoleId = "";
			PlatformSdkReportBaseData.LoginId = "";
			PlatformSdkReportBaseData.BaseGameVersion = "";
			PlatformSdkReportBaseData.BaseSdkVersion = "";
			PlatformSdkReportBaseData.BaseDid = "";
			PlatformSdkReportBaseData.BaseUserId = "";
			PlatformSdkReportBaseData.BaseInitTime = "";
			PlatformSdkReportBaseData.BaseGameId = "";
			PlatformSdkReportBaseData.BaseAccessId = "";
			PlatformSdkReportBaseData.BasePuid = 0L;
		}

		// Token: 0x0602EBEE RID: 191470 RVA: 0x00B12308 File Offset: 0x00B10508
		public PlatformSdkReportBaseData()
		{
			this.event_uuid = UKismetGuidLibrary.NewGuid().ToString();
			this.language = PlatformSdkReportBaseData.BaseLanguage;
			DateTimeOffset utcNow = DateTimeOffset.UtcNow;
			double totalHours = TimeZoneInfo.Local.GetUtcOffset(utcNow).TotalHours;
			string text;
			if (totalHours < 0.0)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<double>(totalHours);
				text = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			else
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
				defaultInterpolatedStringHandler.AppendLiteral("+");
				defaultInterpolatedStringHandler.AppendFormatted<double>(totalHours);
				text = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			this.timezone = text;
			this.pkg_id = PlatformSdkReportBaseData.BasePkgId;
			this.pkg_name = PlatformSdkReportBaseData.BasePkgName;
			this.channel_id = PlatformSdkReportBaseData.BaseChannelId;
			this.channel_name = PlatformSdkReportBaseData.BaseChannelName;
			this.channel_op = PlatformSdkReportBaseData.BaseChannelOp;
			this.role_id = PlatformSdkReportBaseData.BaseRoleId;
			this.role_name = PlatformSdkReportBaseData.BaseRoleName;
			this.server_id = PlatformSdkReportBaseData.BaseServerId;
			this.server_name = PlatformSdkReportBaseData.BaseServerName;
			this.login_id = PlatformSdkReportBaseData.LoginId;
			this.game_version = PlatformSdkReportBaseData.BaseGameVersion;
			this.sdk_version = PlatformSdkReportBaseData.BaseSdkVersion;
			this.did = PlatformSdkReportBaseData.BaseDid;
			this.event_time_ms = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
			this.last_phone_open_ts = PlatformSdkReportBaseData.BaseInitTime;
			this.user_id = PlatformSdkReportBaseData.BaseUserId;
			this.game_id = PlatformSdkReportBaseData.BaseGameId;
			this.psn_access_id = PlatformSdkReportBaseData.BaseAccessId;
			this.puid = PlatformSdkReportBaseData.BasePuid;
		}

		// Token: 0x0602EBEF RID: 191471 RVA: 0x00B12587 File Offset: 0x00B10787
		public virtual string GetReportEventName()
		{
			return this.event_name;
		}

		// Token: 0x0602EBF0 RID: 191472 RVA: 0x00B1258F File Offset: 0x00B1078F
		public virtual string GetCpReportEventName()
		{
			return "cp_" + this.event_name;
		}

		// Token: 0x0602EBF1 RID: 191473 RVA: 0x00B125A1 File Offset: 0x00B107A1
		public virtual string GetReportData()
		{
			return LauncherJson.Stringify<PlatformSdkReportBaseData>(this, new JsonSerializerOptions
			{
				IncludeFields = true
			});
		}

		// Token: 0x0602EBF2 RID: 191474 RVA: 0x00B125B8 File Offset: 0x00B107B8
		public static void InitSdkBaseValue(string pkg_id, string pkg_name, string channel_id, string channel_name, string channel_op, string language, string loginId, string gameVersion, string sdkVersion, string did, string initTime, string gameId, string accessId)
		{
			PlatformSdkReportBaseData.BasePkgId = pkg_id;
			PlatformSdkReportBaseData.BasePkgName = pkg_name;
			PlatformSdkReportBaseData.BaseChannelId = channel_id;
			PlatformSdkReportBaseData.BaseChannelName = channel_name;
			PlatformSdkReportBaseData.BaseChannelOp = channel_op;
			PlatformSdkReportBaseData.LoginId = loginId;
			PlatformSdkReportBaseData.BaseGameVersion = gameVersion;
			PlatformSdkReportBaseData.BaseSdkVersion = sdkVersion;
			PlatformSdkReportBaseData.BaseDid = did;
			PlatformSdkReportBaseData.BaseInitTime = initTime;
			PlatformSdkReportBaseData.BaseGameId = gameId;
			PlatformSdkReportBaseData.BaseAccessId = accessId;
			PlatformSdkReportBaseData.ChangeLanguage(language);
		}

		// Token: 0x0602EBF3 RID: 191475 RVA: 0x00B1261C File Offset: 0x00B1081C
		public static void SetCuid(string cuid)
		{
			PlatformSdkReportBaseData.BaseUserId = cuid;
		}

		// Token: 0x0602EBF4 RID: 191476 RVA: 0x00B12624 File Offset: 0x00B10824
		public static void SetPuid(long puid)
		{
			PlatformSdkReportBaseData.BasePuid = puid;
		}

		// Token: 0x0602EBF5 RID: 191477 RVA: 0x00B1262C File Offset: 0x00B1082C
		public static long GetPuid()
		{
			return PlatformSdkReportBaseData.BasePuid;
		}

		// Token: 0x0602EBF6 RID: 191478 RVA: 0x00B12633 File Offset: 0x00B10833
		public static void ChangeLanguage(string language)
		{
			PlatformSdkReportBaseData.BaseLanguage = language;
		}

		// Token: 0x0602EBF7 RID: 191479 RVA: 0x00B1263B File Offset: 0x00B1083B
		public static void InitSdkRoleValue(string role_id, string role_name, string server_id, string server_name)
		{
			PlatformSdkReportBaseData.BaseRoleId = role_id;
			PlatformSdkReportBaseData.BaseRoleName = role_name;
			PlatformSdkReportBaseData.BaseServerId = server_id;
			PlatformSdkReportBaseData.BaseServerName = server_name;
		}

		// Token: 0x0401A8F9 RID: 108793
		private const string PROJECT_ID = "Aki";

		// Token: 0x0401A8FA RID: 108794
		private const int GLOBALSDKTYPEVALUE = 2;

		// Token: 0x0401A8FB RID: 108795
		private static string BasePkgId = "";

		// Token: 0x0401A8FC RID: 108796
		private static string BasePkgName = "";

		// Token: 0x0401A8FD RID: 108797
		private static string BaseChannelId = "";

		// Token: 0x0401A8FE RID: 108798
		private static string BaseChannelName = "";

		// Token: 0x0401A8FF RID: 108799
		private static string BaseChannelOp = "";

		// Token: 0x0401A900 RID: 108800
		private static string BaseLanguage = "";

		// Token: 0x0401A901 RID: 108801
		private static string BaseRoleName = "";

		// Token: 0x0401A902 RID: 108802
		private static string BaseServerName = "";

		// Token: 0x0401A903 RID: 108803
		private static string BaseServerId = "";

		// Token: 0x0401A904 RID: 108804
		private static string BaseRoleId = "";

		// Token: 0x0401A905 RID: 108805
		private static string LoginId = "";

		// Token: 0x0401A906 RID: 108806
		private static string BaseGameVersion = "";

		// Token: 0x0401A907 RID: 108807
		private static string BaseSdkVersion = "";

		// Token: 0x0401A908 RID: 108808
		private static string BaseDid = "";

		// Token: 0x0401A909 RID: 108809
		private static string BaseUserId = "";

		// Token: 0x0401A90A RID: 108810
		private static string BaseInitTime = "";

		// Token: 0x0401A90B RID: 108811
		private static string BaseGameId = "";

		// Token: 0x0401A90C RID: 108812
		private static string BaseAccessId = "";

		// Token: 0x0401A90D RID: 108813
		private static long BasePuid = 0L;

		// Token: 0x0401A90E RID: 108814
		public long event_time_ms;

		// Token: 0x0401A90F RID: 108815
		public int event_id;

		// Token: 0x0401A910 RID: 108816
		public string event_name = "";

		// Token: 0x0401A911 RID: 108817
		public string event_uuid = "";

		// Token: 0x0401A912 RID: 108818
		public string did = "";

		// Token: 0x0401A913 RID: 108819
		public string language = "";

		// Token: 0x0401A914 RID: 108820
		public string timezone = "";

		// Token: 0x0401A915 RID: 108821
		public string user_id = "";

		// Token: 0x0401A916 RID: 108822
		public string game_id = "";

		// Token: 0x0401A917 RID: 108823
		public string game_name = "Aki";

		// Token: 0x0401A918 RID: 108824
		public string pkg_id = "";

		// Token: 0x0401A919 RID: 108825
		public string pkg_name = "";

		// Token: 0x0401A91A RID: 108826
		public string channel_id = "";

		// Token: 0x0401A91B RID: 108827
		public string channel_name = "";

		// Token: 0x0401A91C RID: 108828
		public string channel_op = "";

		// Token: 0x0401A91D RID: 108829
		public string role_id = "";

		// Token: 0x0401A91E RID: 108830
		public string role_name = "";

		// Token: 0x0401A91F RID: 108831
		public string server_id = "";

		// Token: 0x0401A920 RID: 108832
		public string server_name = "";

		// Token: 0x0401A921 RID: 108833
		public string sdk_version = "";

		// Token: 0x0401A922 RID: 108834
		public string game_version = "";

		// Token: 0x0401A923 RID: 108835
		public string login_id = "";

		// Token: 0x0401A924 RID: 108836
		public string os = "PS5";

		// Token: 0x0401A925 RID: 108837
		public string last_phone_open_ts = "";

		// Token: 0x0401A926 RID: 108838
		public int sdk_type = 2;

		// Token: 0x0401A927 RID: 108839
		public string psn_access_id = "";

		// Token: 0x0401A928 RID: 108840
		public long puid;
	}
}
