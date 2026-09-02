using System;
using System.Runtime.CompilerServices;

// Token: 0x02002130 RID: 8496
[NullableContext(1)]
[Nullable(0)]
public class SettingMenuLogEvent : PlayerCommonLogData
{
	// Token: 0x1700138B RID: 5003
	// (get) Token: 0x06010390 RID: 66448 RVA: 0x004755D8 File Offset: 0x004737D8
	// (set) Token: 0x06010391 RID: 66449 RVA: 0x004755E0 File Offset: 0x004737E0
	public override string event_id { get; set; } = "1017";

	// Token: 0x04007DA7 RID: 32167
	private const int SettingLogDefaultValue = 99999;

	// Token: 0x04007DA9 RID: 32169
	public int i_image_quality;

	// Token: 0x04007DAA RID: 32170
	public int i_display_mode;

	// Token: 0x04007DAB RID: 32171
	public string s_resolution = "";

	// Token: 0x04007DAC RID: 32172
	public int i_brightness;

	// Token: 0x04007DAD RID: 32173
	public int i_highest_fps;

	// Token: 0x04007DAE RID: 32174
	public int i_shadow_quality;

	// Token: 0x04007DAF RID: 32175
	public int i_niagara_quality;

	// Token: 0x04007DB0 RID: 32176
	public int i_fsr;

	// Token: 0x04007DB1 RID: 32177
	public int i_image_detail;

	// Token: 0x04007DB2 RID: 32178
	public int i_scene_ao;

	// Token: 0x04007DB3 RID: 32179
	public int i_volume_Fog;

	// Token: 0x04007DB4 RID: 32180
	public int i_volume_light;

	// Token: 0x04007DB5 RID: 32181
	public int i_motion_blur;

	// Token: 0x04007DB6 RID: 32182
	public int i_anti_aliasing;

	// Token: 0x04007DB7 RID: 32183
	public int i_pcv_sync;

	// Token: 0x04007DB8 RID: 32184
	public int i_horizontal_view_sensitivity;

	// Token: 0x04007DB9 RID: 32185
	public int i_vertical_view_sensitivity;

	// Token: 0x04007DBA RID: 32186
	public int i_aim_horizontal_view_sensitivity;

	// Token: 0x04007DBB RID: 32187
	public int i_aim_vertical_view_sensitivity;

	// Token: 0x04007DBC RID: 32188
	public float f_camera_shake_strength;

	// Token: 0x04007DBD RID: 32189
	public int i_common_spring_arm_length;

	// Token: 0x04007DBE RID: 32190
	public int i_fight_spring_arm_length;

	// Token: 0x04007DBF RID: 32191
	public int i_reset_focus_enable;

	// Token: 0x04007DC0 RID: 32192
	public int i_side_step_camera_enable;

	// Token: 0x04007DC1 RID: 32193
	public int i_soft_lock_camera_enable;

	// Token: 0x04007DC2 RID: 32194
	public int i_joystick_shake_strength;

	// Token: 0x04007DC3 RID: 32195
	public int i_joystick_shake_type;

	// Token: 0x04007DC4 RID: 32196
	public float f_walk_or_run_rate;

	// Token: 0x04007DC5 RID: 32197
	public int i_advice_setting;

	// Token: 0x04007DC6 RID: 32198
	public int i_enemy_id;

	// Token: 0x04007DC7 RID: 32199
	public string i_filter_list = "";

	// Token: 0x04007DC8 RID: 32200
	public int i_image_mode;

	// Token: 0x04007DC9 RID: 32201
	public int eyeprotect_mode;

	// Token: 0x04007DCA RID: 32202
	public string eyeprotect_list = "";

	// Token: 0x04007DCB RID: 32203
	public int i_crowd_density;

	// Token: 0x04007DCC RID: 32204
	public int i_hit_material_effects;

	// Token: 0x04007DCD RID: 32205
	public int i_auto_adjust;

	// Token: 0x04007DCE RID: 32206
	public int i_damage_numbers;

	// Token: 0x04007DCF RID: 32207
	public int i_fluttering_animation;

	// Token: 0x04007DD0 RID: 32208
	public int i_cinematic_quality;

	// Token: 0x04007DD1 RID: 32209
	public int i_teammate_effects;

	// Token: 0x04007DD2 RID: 32210
	public int i_injury_effects;

	// Token: 0x04007DD3 RID: 32211
	public int i_environment_interaction;

	// Token: 0x04007DD4 RID: 32212
	public int i_foliage_blur;

	// Token: 0x04007DD5 RID: 32213
	public int i_auto_exposure;

	// Token: 0x04007DD6 RID: 32214
	public int i_hdr;

	// Token: 0x04007DD7 RID: 32215
	public int i_ui_Brightness;

	// Token: 0x04007DD8 RID: 32216
	public int i_peak_Brightness;

	// Token: 0x04007DD9 RID: 32217
	public int i_recommend_config;

	// Token: 0x04007DDA RID: 32218
	public int anisotropic_sampling = 99999;

	// Token: 0x04007DDB RID: 32219
	public int render_distance = 99999;

	// Token: 0x04007DDC RID: 32220
	public int dlss = 99999;

	// Token: 0x04007DDD RID: 32221
	public int fsr = 99999;

	// Token: 0x04007DDE RID: 32222
	public int xess = 99999;

	// Token: 0x04007DDF RID: 32223
	public int super_resolution = 99999;

	// Token: 0x04007DE0 RID: 32224
	public int ray_tracing = 99999;

	// Token: 0x04007DE1 RID: 32225
	public int rt_reflection = 99999;

	// Token: 0x04007DE2 RID: 32226
	public int rt_global_illumination = 99999;

	// Token: 0x04007DE3 RID: 32227
	public int rt_shadow = 99999;

	// Token: 0x04007DE4 RID: 32228
	public int vulkan = 99999;

	// Token: 0x04007DE5 RID: 32229
	public int pc_frame_interpolation = 99999;

	// Token: 0x04007DE6 RID: 32230
	public int mob_frame_interpolation = 99999;

	// Token: 0x04007DE7 RID: 32231
	public int self_dev_interpolation = 99999;

	// Token: 0x04007DE8 RID: 32232
	public int game_language = 99999;

	// Token: 0x04007DE9 RID: 32233
	public int game_voice = 99999;
}
